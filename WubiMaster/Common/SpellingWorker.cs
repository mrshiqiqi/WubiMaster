using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WubiMaster.Models;

namespace WubiMaster.Common
{
    public enum SpellingType
    {
        Spelling86 = 86,
        Spelling98 = 98,
        Spelling06 = 06,
    }

    public static class SpellingWorker
    {
        private static ConcurrentQueue<SpellingModel> spellingQueue06;
        private static ConcurrentQueue<SpellingModel> spellingQueue86;

        private static ConcurrentQueue<SpellingModel> spellingQueue98;

        public static ConcurrentQueue<SpellingModel> SpellingQueue06
        {
            get
            {
                if (spellingQueue06 == null)
                    spellingQueue06 = SpellingWorker.GetSpellingData(SpellingType.Spelling06);
                return spellingQueue06;
            }
            set { spellingQueue06 = value; }
        }

        public static ConcurrentQueue<SpellingModel> SpellingQueue86
        {
            get
            {
                if (spellingQueue86 == null)
                    spellingQueue86 = SpellingWorker.GetSpellingData(SpellingType.Spelling86);
                return spellingQueue86;
            }
            set { spellingQueue86 = value; }
        }

        public static ConcurrentQueue<SpellingModel> SpellingQueue98
        {
            get
            {
                if (spellingQueue98 == null)
                    spellingQueue98 = SpellingWorker.GetSpellingData(SpellingType.Spelling98);
                return spellingQueue98;
            }
            set { spellingQueue98 = value; }
        }

        public static ConcurrentQueue<SpellingModel> GetSpellingData(SpellingType type)
        {
            try
            {
                string typeStr;
                switch (type)
                {
                    case SpellingType.Spelling86:
                        typeStr = "86";
                        break;

                    case SpellingType.Spelling98:
                        typeStr = "98";
                        break;

                    case SpellingType.Spelling06:
                        typeStr = "06";
                        break;

                    default:
                        typeStr = "86";
                        break;
                }

                return ReadSpellingText(typeStr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ConcurrentQueue<SpellingModel> GetSpellingData(string type)
        {
            try
            {
                if (string.IsNullOrEmpty(type)) throw new ArgumentNullException(nameof(type), "参数不可为空");
                return ReadSpellingText(type);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static ConcurrentQueue<SpellingModel> ReadSpellingText(string type)
        {
            ConcurrentQueue<SpellingModel> tempQueue = new ConcurrentQueue<SpellingModel>();
            string spellingFile = AppDomain.CurrentDomain.BaseDirectory + @$"Assets\Spelling\wb{type}_spelling.txt";

            string[] spellingDatas = File.ReadAllLines(spellingFile);
            Parallel.For(0, spellingDatas.Length,
              index =>
              {
                  string[] tempArray = new string[] { "", "", "", "" };
                  SpellingModel model = new SpellingModel();
                  string dataStr = spellingDatas[index];
                  string[] dataKeyValue = dataStr.Split('\t');
                  string _tempStr = dataKeyValue[1].Replace('[', ' ').Replace(']', ' ').Replace('※', ' ');
                  string[] spelldata = _tempStr.Split(',');

                  model.Text = dataKeyValue[0].Trim();
                  model.Spelling = spelldata[0].Trim();
                  model.Code = spelldata[1].Trim();
                  if (spelldata.Length > 3)
                      model.Pinyin = spelldata[2].Split('_').Where(p => p.Trim().Length > 0).Select(p => p.Trim()).ToArray();
                  model.GBType = spelldata[^1].Trim();
                  tempQueue.Enqueue(model);
              });

            return tempQueue;
        }

        public static void LoadAllSpellingData()
        {
            _ = SpellingWorker.SpellingQueue86;
            _ = SpellingWorker.SpellingQueue98;
            _ = SpellingWorker.SpellingQueue06;
        }

        public static SpellingModel? ZingenSearch(string text, SpellingType type)
        {
            try
            {
                ConcurrentQueue<SpellingModel> QuickSpellingQueue = new ConcurrentQueue<SpellingModel>();
                switch (type)
                {
                    case SpellingType.Spelling86:
                        QuickSpellingQueue = SpellingWorker.SpellingQueue86;
                        break;

                    case SpellingType.Spelling98:
                        QuickSpellingQueue = SpellingWorker.SpellingQueue98;
                        break;

                    case SpellingType.Spelling06:
                        QuickSpellingQueue = SpellingWorker.SpellingQueue06;
                        break;

                    default:
                        QuickSpellingQueue = SpellingWorker.SpellingQueue86;
                        break;
                }

                string keyWord = text.Trim();
                var result = QuickSpellingQueue.AsParallel().FirstOrDefault(s => s.Text == keyWord);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SpellingModel? ZingenSearch(string text, string type)
        {
            try
            {
                ConcurrentQueue<SpellingModel> QuickSpellingQueue = new ConcurrentQueue<SpellingModel>();
                if (type == "86")
                    QuickSpellingQueue = SpellingWorker.SpellingQueue86;
                else if (type == "98")
                    QuickSpellingQueue = SpellingWorker.SpellingQueue98;
                else if (type == "06")
                    QuickSpellingQueue = SpellingWorker.SpellingQueue06;
                else
                    QuickSpellingQueue = SpellingWorker.SpellingQueue86;

                string keyWord = text.Trim();
                var result = QuickSpellingQueue.AsParallel().FirstOrDefault(s => s.Text == keyWord);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}