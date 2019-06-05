using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClock.ProjectClass
{
    public class WavToTaskcontent 
    {
        public static Dictionary<string, string> dicWavToTaskcontent = new Dictionary<string, string>();
        static WavToTaskcontent()
        {
            List<string> listContent = FileHelper.getContentList(AppDomain.CurrentDomain.BaseDirectory + "WavReflectTaskcontent.txt");
            foreach(string str in listContent)
            {
                string[] strArray = str.Split('|');
                dicWavToTaskcontent.Add(strArray[0].Trim(), strArray[1]);
            }
        }
        public static void AddDicitem(string taskcontent)
        {
            dicWavToTaskcontent.Add(taskcontent, "未知任务.wav");
        }

        public static string GetWavfilename(string taskcontent)
        {
            string filename = "";
            filename = dicWavToTaskcontent[taskcontent]; 
            return filename;
        }
    }
}
