using System;
using System.IO;
using Z = System.IO.Compression;
using System.Collections.Generic;
using System.Text;

namespace QWK
{
    /*
    -----------------------------------------------------------------------------------------
    CONTROL.DAT
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

    -----------------------------------------------------------------------------------------
    MESSAGES.DAT 
    -----------------------------------------------------------------------------------------
    Offset  Length  Description
    ------  ------  -------------------------------------------------------------------------
    001     001     Message status flag (unsigned character)
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
    002       7     Message number (in ASCII)
    009       8     Date (mm-dd-yy, in ASCII)
    017       5     Time (24 hour hh:mm, in ASCII)
    022      25     To (uppercase, left justified)
    047      25     From (uppercase, left justified)
    072      25     Subject of message (mixed case)
    097      12     Password (space filled)
    109       8     Reference message number (in ASCII)
    117       6     Number of 128-bytes blocks in message 
    123       1     Flag (ASCII 225 means message is active; ASCII 226 means this message is to be killed)
    124       2     Conference number (unsigned word)
    126       2     Logical message number in the current packet
    128       1     Indicates whether the message has a network tag-line or not. '*' ' ' 
    -----------------------------------------------------------------------------------------
    */

    public class MessageHeader
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
        public Int32 BytesBlocks { get; set; }
        public string DeleteFlag { get; set; }
        public string ConferenceNumber { get; set; }
        public string NumberInCurrentePacket { get; set; }
        public string TagLineFlag { get; set; }
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
    }

    public class Forum
    {
        public string ForumID { get; set; }
        public string ForumName { get; set; }
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
            var sb = new StringBuilder();
            sb.Append(tmpdir);
            sb.Append("CONTROL.DAT");
            string[] lines = File.ReadAllLines(sb.ToString());
            return lines;
        }

        private static byte[] GetMessageDatBytes(string tmpdir)
        {
            var sb = new StringBuilder();
            sb.Append(tmpdir);
            sb.Append("MESSAGES.DAT");
            var strBytes = File.ReadAllBytes(sb.ToString());
            return strBytes;
        }


        private static string[] OpenMessageDat(string tmpdir)
        {
            var sb = new StringBuilder();
            sb.Append(tmpdir);
            sb.Append("MESSAGES.DAT");
            string[] lines = File.ReadAllLines(sb.ToString());
            return lines;
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
                    forum.ForumID = lines[i];
                    forum.ForumName = lines[i + 1];
                    foruns.Add(forum);
                }
            }
            return foruns;
        }

        public static List<MessageHeader> GetAllHeaders(string tmpdir)
        {
            var messsageHeaders = new List<MessageHeader>();
            var allBytes = GetMessageDatBytes(tmpdir);
            var header = GetMessageHeader(tmpdir, 128);
            messsageHeaders.Add(header);
            int messageBlocks = header.BytesBlocks * 128;
            int nextBlock = messageBlocks + 128;
            while (nextBlock < allBytes.Length)
            {
                header = GetMessageHeader(tmpdir, nextBlock);
                messsageHeaders.Add(header);
                messageBlocks = header.BytesBlocks * 128;
                nextBlock = nextBlock + messageBlocks;
            }
            return messsageHeaders;
        }


        public static MessageHeader GetMessageHeader(string tmpDirectory, int start)
        {
            var header = new MessageHeader();
            var strHeader = Get128ByteBlock(tmpDirectory, start);
            header.StatusFlag = strHeader.Substring(0, 1);
            header.From = strHeader.Substring(46, 25);
            header.To = strHeader.Substring(21, 25);
            header.Subject = strHeader.Substring(71, 25);
            header.BytesBlocks = Convert.ToInt32(strHeader.Substring(116, 6));
            header.ConferenceNumber = strHeader.Substring(124, 2);
            header.DeleteFlag = strHeader.Substring(124, 2);
            return header;
        }

        private static string Get128ByteBlock(string tmpDirectory, int start)
        {
            var allBytes = GetMessageDatBytes(tmpDirectory);
            byte[] byteBlock = new byte[128];
            var bytecount = start;
            var newBlockCount = 0;

            while (newBlockCount < 128)
            {
                byteBlock[newBlockCount] = allBytes[bytecount];
                newBlockCount++;
                bytecount++;
            }

            var strReturn = Encoding.ASCII.GetString(byteBlock, 0, byteBlock.Length);
            return strReturn;
        }

        /* 
       private static Int64 ConvertMSMKSToLong(byte[] mksNumber)
       {

           Int64 convertedNumber = (((m1 + ((unsigned long) m2 << 8) +((unsigned long) m3 << 16)) | 0x800000L) >> (24 - (exp - 0x80))); 
           return convertedNumber;
         
    }
          */
    }
}
