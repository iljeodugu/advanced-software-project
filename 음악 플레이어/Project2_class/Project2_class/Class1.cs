using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Project2_class
{
    [Serializable]
    public struct dir_info
    {
        public bool is_dir;
        public string file_name;
    }

    [Serializable]
    public enum PacketType
    {
        초기화데이터요청 = 0,
        초기화데이터응답,
        beforeExpand요청,
        beforeExpand응답,
        beforeSelect요청,
        beforeSelect응답,
        상세정보요청,
        상세정보응답
    }
    [Serializable]
    public enum PacketSendERROR
    {
        정상 = 0,
        에러
    }
    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;

        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }
        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
            {
                ms.WriteByte(b);
            }

            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
    [Serializable]
    public class folder_Info : Packet
    {
        public string folder_name;
        public string folder_type;
        public string folder_size;
        public string make_time;
        public string fix_time;
        public string access_time;
    }

    [Serializable]
    public class file_info : Packet
    {
        public string file_name;
        public string file_type;
        public string file_size;
        public string make_time;
        public string fix_time;
        public string access_time;
    }
    
    [Serializable]
    public class init_data_request : Packet
    {
    }

    [Serializable]
    public class init_data_response : Packet
    {
        public string rootName;
    }
    
    [Serializable]
    public class before_expand_request : Packet
    {
        public string dir_path;
    }

    [Serializable]
    public class before_expand_response : Packet
    {
        public dir_info[] dir_list;
    }

    [Serializable]
    public class before_select_request : Packet
    {
        public string dir_path;
    }

    [Serializable]
    public class before_select_response : Packet
    {
        public DirectoryInfo[] diArray;
        public int diArray_len;
        public FileInfo[] fiArray;
        public int fiArray_len;
    }

    [Serializable]
    public class detail_info_request : Packet
    {
        public string detail_path;
        public string file_type;
    }

    [Serializable]
    public class detail_info_response : Packet
    {
        public string dir_type;
        public FileInfo file_info;
        public DirectoryInfo di_info;
    }
}
