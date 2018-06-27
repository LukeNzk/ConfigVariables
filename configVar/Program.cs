using System.IO;

namespace configVar
{
    class Program
    {
        static CVar<float> cvSpeed = new CVar<float>("speed", 0.0f);
        static CVar<byte> cvSthElse = new CVar<byte>("someVar", 3);
        static CVar<string> cvSomeString = new CVar<string>("name", "");
        static CVar<int> cvEnemiesCount = new CVar<int>("nEnemies", 0);
        static CVar<string> cvCharacterLocation = new CVar<string>("loc", "limbo");

        static void LoadConfigFile()
        {
            string path = "../../config.txt";
            if (!File.Exists(path))
                File.Create(path);

            using (TextReader reader = File.OpenText(path))
                ConfigParser.Parse(reader.ReadToEnd());
        }

        static void Main(string[] args)
        {
            LoadConfigFile();

            ConfigRegistry.Dump();
        }
    }
}
