using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace Project_class
{
    public enum FileDataType
    {
        로그인 = 0,
        텍스트파일,
        파일,
        접속목록,
        파일체크,
        파일리스트
    }
     

    [Serializable]
    public class FileData
    {
        public int Length;
        public int Type;

        public FileData()
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

        public static Object Deserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
                ms.WriteByte(b);

            ms.Position = 0;

            BinaryFormatter bf = new BinaryFormatter();
            bf.Binder = new AllowAllAssemblyVersionsDeserializationBinder();

            Object obj = bf.Deserialize(ms);
            ms.Close();

            return obj;
        }
    }

    sealed class AllowAllAssemblyVersionsDeserializationBinder : System.Runtime.Serialization.SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;

            String currentAssembly = Assembly.GetExecutingAssembly().FullName;

            assemblyName = currentAssembly;

            typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
                typeName, assemblyName));

            return typeToDeserialize;
        }
    }

    [Serializable]
    public class login : FileData
    {
        public string id;
        public bool logout;

        public login(string id)
        {
            this.id = id;
            this.logout = false;
        }
    }

    [Serializable]
    public class textFile : FileData
    {
        public string text;
        public string userName;//파일 이름
        public int userIndex;

        public textFile(string text)
        {
            this.text = text;
        }
    }

    [Serializable]
    public class myFile : FileData
    {
        public byte[] data;
        public string filename;
        public int size;
        public myFile()
        {
            data = new byte[1024 * 4];
            size = 0;
        }
    }

    [Serializable]
    public class listItem : FileData
    {
        public bool first;
        public string[] list;
        public int index;
        public listItem()
        {
            list = new string[3];
            for (int i = 0; i < 3; i++)
                list[i] = null;
            index = -1;
            first = false;
        }
    }

    [Serializable]
    public class fileCheck : FileData
    {
        public int fileNeed;//필요한 파일 타입 말하기, 0은 텍스트 1은 파일
        public int fileNumber;//누구 파일인지
        public string filename;
    }

    [Serializable]
    public class filelist : FileData
    {
        public string fileList;//필요한 파일 타입 말하기, 0은 텍스트 1은 파일
    }
}
