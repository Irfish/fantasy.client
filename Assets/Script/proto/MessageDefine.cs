using System;
using System.Collections.Generic;
using Google.Protobuf;

namespace Pb
{
    /// <summary>
    /// TODO 编写工具更新该类
    /// </summary>
    public class MessageDefine
    {
        private static List<int> m_protoId = new List<int>
        {
            0,
            //UserAuthentication
            1,
            2,
           
            3,
            4,

            5,
            6,

            7,
            8,
        };

        private static List<Type> m_protoType = new List<Type>
        {
            typeof(Message),

            typeof(CtsUserAuthentication),
            typeof(StcUserAuthentication),
            //1 2
            typeof(CtsUserEnter),
            typeof(StcUserEnter),

            typeof(CtsUserLeave),
            typeof(StcUserLeave),

            typeof(CtsCreateRoom),
            typeof(StcCreateRoom),

        };

        private static readonly Dictionary<RuntimeTypeHandle, MessageParser> Parsers = new Dictionary<RuntimeTypeHandle, MessageParser>()
        {
            {typeof(Message).TypeHandle,Message.Parser },

            {typeof(CtsUserAuthentication).TypeHandle,CtsUserAuthentication.Parser },
            {typeof(StcUserAuthentication).TypeHandle,StcUserAuthentication.Parser },

            {typeof(CtsUserEnter).TypeHandle,CtsUserEnter.Parser },
            {typeof(StcUserEnter).TypeHandle,StcUserEnter.Parser },

            {typeof(CtsUserLeave).TypeHandle,CtsUserLeave.Parser },
            {typeof(StcUserLeave).TypeHandle,StcUserLeave.Parser },

            {typeof(CtsCreateRoom).TypeHandle,CtsCreateRoom.Parser },
            {typeof(StcCreateRoom).TypeHandle,StcCreateRoom.Parser },

        };


        public static MessageParser GetMessageParser(RuntimeTypeHandle typeHandle)
        {
            MessageParser messageParser;

            Parsers.TryGetValue(typeHandle, out messageParser);

            return messageParser;
        }

        public static Type GetProtoTypeByProtoId(int protoId)
        {
            int index = m_protoId.IndexOf(protoId);

            return m_protoType[index];
        }

        public static int GetProtoIdByProtoType(Type type)
        {
            int index = m_protoType.IndexOf(type);

            return m_protoId[index];
        }

        public static bool ContainProtoId(int protoId)
        {
            if (m_protoId.Contains(protoId))
            {
                return true;
            }
            return false;
        }

        public static bool ContainProtoType(Type type)
        {
            if (m_protoType.Contains(type))
            {
                return true;
            }
            return false;
        }

    }
}
