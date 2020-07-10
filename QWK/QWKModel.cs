using System;
using System.IO;
using Z = System.IO.Compression;
using System.Collections.Generic;
using System.Text;

namespace QWK
{

    public class Message
    {
        public string StatusFlag { get; set; }
        public string MessageNumber { get; set; }
        public string MessageDate { get; set; }
        public string MessageTime { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Password { get; set; }
        public string ReferenceMessageNumber { get; set; }
        public Int32 MessageBlocks { get; set; }
        public string DeleteFlag { get; set; }
        public string ConferenceNumber { get; set; }
        public string NumberInCurrentePacket { get; set; }
        public string TagLineFlag { get; set; }
        public string Body { get; set; }
    }

    public class BBSInfo
    {
        public string BbsName { get; set; }
        public string BbsPhone { get; set; }
        public string BbsLocation { get; set; }
        public string MailDoorReg { get; set; }
        public string MailPacketCreationTime { get; set; }
        public string SysopName { get; set; }
        public string UserName { get; set; }
        public string BbsId { get; set; }
        public Int32 MessagesInPacket { get; set; }
    }

    public class Forum
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int NumberOfMessages { get; set; }

    }

    public class MessagePointer
    {
        public ulong messageBytesLocation { get; set; }
    }

    public class Methods
    {
        public static void OpenQWKPacket(string packet, string tmpdir)
        {
            if (Directory.Exists(tmpdir))
            {
                var files = Directory.GetFiles(tmpdir);
                for (var i = 0; i < files.Length; i++)
                {
                    File.Delete(files[i]);
                }
                Directory.Delete(tmpdir);
            }
            Directory.CreateDirectory(tmpdir);
            Z.ZipFile.ExtractToDirectory(packet, tmpdir);
        }

        private static string[] OpenControlDat(string tmpdir)
        {
            /*
            -----------------------------------------------------------------------------------------
            CONTROL.DAT (Ascii File)
            -----------------------------------------------------------------------------------------
            Line #
            1   My BBS                   BBS name
            2   New York, NY             BBS city and state
            3   212-555-1212             BBS phone number
            4   John Doe, Sysop          BBS Sysop name
            5   20052,MYBBS              Mail door registration #, BBSID
            6   01-01-1991,23:59:59      Mail packet creation time
            7   JANE DOE                 User name (upper case)
            8                            Name of menu for Qmail, blank if none
            9   0                        ? Seem to be always zero
            10   999                      Total number of messages in packet
            11   121                      Total number of conference minus 1
            12   0                        1st conf. number
            13   Main Board               1st conf. name (13 characters or less)
            14   1                        2nd conf. number
            15   General                  2nd conf. name
            ..   3                        etc. onward until it hits max. conf.
            ..   123                      Last conf. number
            ..   Amiga_I                  Last conf. name
            ..   HELLO                    Welcome screen file
            ..   NEWS                     BBS news file
            ..   SCRIPT0                  Log off screen
            -----------------------------------------------------------------------------------------
            */
            var sb = new StringBuilder();
            sb.Append(tmpdir);
            sb.Append("CONTROL.DAT");
            string[] lines = File.ReadAllLines(sb.ToString());
            return lines;
        }

        private static byte[] OpenNDXFile(string tmpdir, string forumId)
        {
            /*
            -----------------------------------------------------------------------------------------
            XXXX.NDX(Byte Array)
            -----------------------------------------------------------------------------------------
            Offset  Length Description
            ------------------------------------------------------------------
            1       4   Record number pointing to corresponding message in
                        MESSAGES.DAT.This number is in the Microsoft MKS$
                        BASIC format.
            5       1   Conference number of the message.This byte should
                        not be used because it duplicates both the filename of
                        the index file and the conference # in the header.  It
                        is also one byte long, which is insufficient to handle
                        conferences over 255.
            -----------------------------------------------------------------------------------------
            */
            var sb = new StringBuilder();
            byte[] byteArray = { new byte() };
            sb.Append(tmpdir);
            sb.Append(forumId);
            sb.Append(".NDX");
            if (File.Exists(sb.ToString()))
            {
                byteArray = File.ReadAllBytes(sb.ToString());
            }
            return byteArray;
        }

        private static byte[] OpenMessageDat(string tmpdir)
        {
            var sb = new StringBuilder();
            sb.Append(tmpdir);
            sb.Append("MESSAGES.DAT");
            var strBytes = File.ReadAllBytes(sb.ToString());
            return strBytes;
        }

        public static BBSInfo GetBBSInfo(string tmpdir)
        {
            var bbsInfo = new BBSInfo();
            var lines = OpenControlDat(tmpdir);
            bbsInfo.BbsName = lines[0];
            bbsInfo.BbsLocation = lines[1];
            bbsInfo.BbsPhone = lines[2];
            bbsInfo.SysopName = lines[3];
            bbsInfo.MailDoorReg = lines[4];
            bbsInfo.MailPacketCreationTime = lines[5];
            bbsInfo.UserName = lines[6];
            bbsInfo.MessagesInPacket = Convert.ToInt32(lines[9]);
            return bbsInfo;
        }

        public static List<Forum> GetForuns(string tmpdir)
        {
            var foruns = new List<Forum>();
            var lines = OpenControlDat(tmpdir);
            int contaAreas = Convert.ToInt32(lines[10]);

            for (var i = 11; i < contaAreas; i++)
            {
                if (i % 2 != 0)
                {
                    var forum = new Forum();
                    forum.ID = lines[i];
                    forum.Name = lines[i + 1];
                    forum.NumberOfMessages = GetForumNumberOfMessages(lines[i]);
                    foruns.Add(forum);
                }
            }
            return foruns;
        }

        public static Int32 GetForumNumberOfMessages(string forumId)
        {
            var pointers = OpenNDXFile("TMP\\", forumId);
            if (pointers.Length < 5) return 0;
            int NumOfMessages = pointers.Length / 5;
            return NumOfMessages;
        }

        public static Message GetMessage(string tmpDirectory, Int64 start)
        {
            /*
            -----------------------------------------------------------------------------------------
            MESSAGES.DAT(Byte Array)
            ---------------------------------------------------------------------------------------- -
            Offset  Length Description
            -------------------------------------------------------------------------------------
            001     001     Message status flag(unsigned character)
                            ' ' = public, unread
                            '-' = public, read
                            '*' = private, read by someone but not by intended recipient
                            '+' = private, read by official recipient
                            '~' = comment to Sysop, unread
                            '`' = comment to Sysop, read
                            '%' = sender password protected, unread
                            '^' = sender password protected, read
                            '!' = group password protected, unread
                            '#' = group password protected, read
                            '$' = group password protected to all
            002       7     Message number(in ASCII)
            009       8     Date(mm-dd-yy, in ASCII)
            017       5     Time(24 hour hh:mm, in ASCII)
            022      25     To(uppercase, left justified)
            047      25     From(uppercase, left justified)
            072      25     Subject of message(mixed case)
            097      12     Password(space filled)
            109       8     Reference message number(in ASCII)
            117       6     Number of 128-bytes blocks in message 
            123       1     Flag(ASCII 225 means message is active; ASCII 226 means this message
                            is to be killed)
            124       2     Conference number (unsigned word)
            126       2     Logical message number in the current packet
            128       1     Indicates whether the message has a network tag-line or not. '*' ' ' 
            ----------------------------------------------------------------------------------------- 
            */

            try
            {
                var message = new Message();
                var countBlocks = 1;
                var strBlock = new StringBuilder();
                var strHeader = Get128ByteBlock(tmpDirectory, start);
                var pointerCount = start + 128;

                message.StatusFlag = strHeader.Substring(0, 1);
                message.From = strHeader.Substring(46, 25);
                message.To = strHeader.Substring(21, 25);
                message.Subject = strHeader.Substring(71, 25);
                message.MessageBlocks = Convert.ToInt32(strHeader.Substring(116, 6));
                message.DeleteFlag = strHeader.Substring(122, 1);
                message.ConferenceNumber = strHeader.Substring(123, 2);

                while (countBlocks <= message.MessageBlocks)
                {
                    strBlock.Append(Get128ByteBlock(tmpDirectory, pointerCount));
                    pointerCount = pointerCount + 128;
                    countBlocks++;
                }

                message.Body = strBlock.ToString();
                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static string Get128ByteBlock(string tmpDirectory, Int64 start)
        {
            var allBytes = OpenMessageDat(tmpDirectory);
            byte[] byteBlock = new byte[128];
            var newBlockCount = 0;
            var bytecount = start;

            while (newBlockCount <= 127)
            {
                byteBlock[newBlockCount] = allBytes[bytecount];
                newBlockCount++;
                bytecount++;
            }

            var strReturn = Encoding.ASCII.GetString(byteBlock, 0, 127);
            return strReturn;
        }

        public static List<MessagePointer> GetMessagePointers(string tmpdir, string forumId)
        {
            List<MessagePointer> messagePointers = new List<MessagePointer>();

            try
            {
                byte[] ndxSourceFile = OpenNDXFile(tmpdir, forumId);
                if (ndxSourceFile.Length < 4) throw new Exception("There is no message in this forum.");
                byte[] nextPointer = {0, 0, 0, 0};
                long countBytes = 0;

                while (countBytes < ndxSourceFile.Length)
                {
                    nextPointer[0] = ndxSourceFile[countBytes];
                    nextPointer[1] = ndxSourceFile[countBytes + 1];
                    nextPointer[2] = ndxSourceFile[countBytes + 2];
                    nextPointer[3] = ndxSourceFile[countBytes + 3];
                    var messagePointer = new MessagePointer();
                    var recordNumber = GetRecordNumber(nextPointer); 
                    messagePointer.messageBytesLocation = (recordNumber-1)* 128;
                    messagePointers.Add(messagePointer);
                    countBytes = countBytes + 5;
                }
                return messagePointers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static ulong GetRecordNumber(byte[] pointerByte)
        {
            /*
            --------------------------------------------------------
            Microsoft binary (by Jeffery Foy)
            --------------------------------------------------------
            31 - 24    23     22 - 0        <-- bit position 32 bits
            +-----------------+----------+
            | exponent | sign | mantissa |
            +----------+------+----------+
            -------------------------------------------------------
            */

            return ((pointerByte[0] + ((ulong)pointerByte[1] << 8) + 
                ((ulong)pointerByte[2] << 16)) | 0x800000L) >> (24 - (pointerByte[3] - 0x80));
        }
    }
}
