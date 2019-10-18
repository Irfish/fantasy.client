using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pb;
using Google.Protobuf;

namespace Pb
{
    public class  MessageDefine
    {
        private static List<int> m_protoId = new List<int>
        {
            0,
            1,
            2,
        };

        private static List<Type> m_protoType = new List<Type>
        {
            typeof(Message),
            typeof(CtsUserEnter),
            typeof(StcUserEnter),
        };

        private static readonly Dictionary<RuntimeTypeHandle, MessageParser> Parsers = new Dictionary<RuntimeTypeHandle, MessageParser>()
        {
            {typeof(Message).TypeHandle,Message.Parser },
            {typeof(CtsUserEnter).TypeHandle,CtsUserEnter.Parser },
            {typeof(StcUserEnter).TypeHandle,StcUserEnter.Parser },
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
