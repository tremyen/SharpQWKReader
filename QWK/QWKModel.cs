using System;
using T = System.Text;
using System.IO;
using Z = System.IO.Compression;
using System.Collections.Generic;

namespace QWK
{
    /*
# MESSAGES.DAT record:
# Offset  Length  Description
#------  ------  ----------------------------------------------------
#    1       1   Message status flag (unsigned character)
#                ' ' = public, unread
#                '-' = public, read
#                '*' = private, read by someone but not by intended recipient
#                '+' = private, read by official recipient
#                '~' = comment to Sysop, unread
#                '`' = comment to Sysop, read
#                '%' = sender password protected, unread
#                '^' = sender password protected, read
#                '!' = group password protected, unread
#                '#' = group password protected, read
#                '$' = group password protected to all
#    2       7   Message number (in ASCII)
#    9       8   Date (mm-dd-yy, in ASCII)
#   17       5   Time (24 hour hh:mm, in ASCII)
#   22      25   To (uppercase, left justified)
#   47      25   From (uppercase, left justified)
#   72      25   Subject of message (mixed case)
#   97      12   Password (space filled)
#  109       8   Reference message number (in ASCII)
#  117       6   Number of 128-bytes blocks in message (including the
# header, in ASCII; the lowest value should be 2, header
# plus one block message; this number may not be left
# flushed within the field)
#  123       1   Flag (ASCII 225 means message is active; ASCII 226
# means this message is to be killed)
#  124       2   Conference number (unsigned word)
#  126       2   Logical message number in the current packet; i.e.
# this number will be 1 for the first message, 2 for the
# second, and so on. (unsigned word)
#  128       1   Indicates whether the message has a network tag-line
# or not.  A value of '*' indicates that a network tag-
#line is present; a value of ' ' (space) indicates
# there isn't one.  Messages sent to readers (non-net-
# status) generally leave this as a space.  Only network
# softwares need this information.
    */

    public class QWKMessge
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
        public string BytesBlocks { get; set; }
        public string DeleteFlag { get; set; }
        public string ConferenceNumber { get; set; }
        public string NumberInCurrentePacket { get; set; }
        public string TagLineFlag { get; set; }    
    }

    public class BBSInfo
    {
        public string BbsName { get; set; }
        public string BbsId { get; set; }
    }

    public class Forum
    { 
        public string ForumName { get; set; }
        public string NumberOfMessages { get; set; }
    }

    public class Methods
    {
        public static void OpenQWKPacket()
        {
            Directory.Delete("tmp\\");
            Directory.CreateDirectory("tmp\\");
            Z.ZipFile.ExtractToDirectory("ABUTRE2.qwk", "tmp\\"); 
        }

        public static List<Forum> GetForuns()
        {
            var foruns = new List<Forum>();
            string[] lines = File.ReadAllLines("tmp\\CONTROL.DAT");
            for(var i=11;i<lines.Length;i++)
            {
                var forum = new Forum();
                forum.ForumName = lines[i];
                i++;
                forum.NumberOfMessages = lines[i];
                foruns.Add(forum);
            }
            return foruns;
        }

        public static List<QWKMessge> GetAllMessages(string tmpDirectory)
        {
            var messages = new List<QWKMessge>();
            var sb = new StringBuilder();
            sb.Append(tmpDirectory);
            sb.Append("MESSAGES.DAT");
            string[] lines = File.ReadAllLines(sb.ToString());

            for (var i = 0; i <= lines.Length; i++)
            {
                var qwkMessage = new QWKMessge();
                qwkMessage.StatusFlag = lines[i].Substring(0, 1);
                qwkMessage.From = lines[i].Substring(46, 25);
                qwkMessage.To = lines[i].Substring(21, 25);
                qwkMessage.BytesBlocks = lines[i].Substring(117, 6);
                qwkMessage.ConferenceNumber = lines[i].Substring(124, 2);
                qwkMessage.DeleteFlag = lines[i].Substring(124, 2);
                messages.Add(qwkMessage);
            }

            return messages;
        }
    }


}
