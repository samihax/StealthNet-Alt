//RShare
//Copyright (C) 2009 Lars Regensburger

//This program is free software; you can redistribute it and/or
//modify it under the terms of the GNU General Public License
//as published by the Free Software Foundation; either version 2
//of the License, or (at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program; if not, write to the Free Software
//Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

using Regensburger.RCollections.ArrayBased;
using System;

namespace Regensburger.RShare
{
    internal sealed class Command70
        : Command, IResponseCommand
    {
        private byte[] m_CommandID;

        private byte[] m_FeedbackID;

        private byte[] m_HashedFileHash;

        private byte[] m_ReceiverPeerID;

        private byte[] m_SenderPeerID;

        public byte[] CommandID
        {
            get
            {
                return m_CommandID;
            }
        }

        public byte[] FeedbackID
        {
            get
            {
                return m_FeedbackID;
            }
        }

        public byte[] HashedFileHash
        {
            get
            {
                return m_HashedFileHash;
            }
        }

        public byte[] ReceiverPeerID
        {
            get
            {
                return m_ReceiverPeerID;
            }
        }

        public byte[] SenderPeerID
        {
            get
            {
                return m_SenderPeerID;
            }
        }

        public Command70(CommandBuilder command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            m_Command = command;
            m_CommandID = m_Command.ReadBytes(48);
            m_SenderPeerID = m_Command.ReadBytes(48);
            m_ReceiverPeerID = m_Command.ReadBytes(48);
            m_FeedbackID = m_Command.ReadBytes(48);
            m_HashedFileHash = m_Command.ReadBytes(64);
        }

        public Command70(byte[] commandID, byte[] senderPeerID, byte[] receiverPeerID, byte[] feedbackID, byte[] hashedFileHash)
        {
            if (commandID == null)
                throw new ArgumentNullException("commandID");
            if (commandID.Length != 48)
                throw new ArgumentException();
            if (senderPeerID == null)
                throw new ArgumentNullException("senderPeerID");
            if (senderPeerID.Length != 48)
                throw new ArgumentException();
            if (receiverPeerID == null)
                throw new ArgumentNullException("receiverPeerID");
            if (receiverPeerID.Length != 48)
                throw new ArgumentException();
            if (feedbackID == null)
                throw new ArgumentNullException("feedbackID");
            if (feedbackID.Length != 48)
                throw new ArgumentException();
            if (hashedFileHash == null)
                throw new ArgumentNullException("hashedFileHash");
            if (hashedFileHash.Length != 64)
                throw new ArgumentException();

            m_CommandID = commandID;
            m_SenderPeerID = senderPeerID;
            m_ReceiverPeerID = receiverPeerID;
            m_FeedbackID = feedbackID;
            m_HashedFileHash = hashedFileHash;
            m_Command = new CommandBuilder(CommandBuilder.EncryptionMethod.Rijndael, 0x70);
            m_Command.Write((byte)0x70);
            m_Command.Write(m_CommandID);
            m_Command.Write(m_SenderPeerID);
            m_Command.Write(m_ReceiverPeerID);
            m_Command.Write(m_FeedbackID);
            m_Command.Write(m_HashedFileHash);
        }
    }
}