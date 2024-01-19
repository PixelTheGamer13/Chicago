using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicago
{
    class Kortlek
    {
        public List<string> skapaKortlek()
        {
            List<string> skapakortlek = new List<string>();
            string[] färger = new string[4] { "H", "R", "K", "S" };
            string kort;

            for (int i = 1; i < 14; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (i)
                    {
                        case 1:
                            kort = färger[j] + "A";
                            skapakortlek.Add(kort);
                            break;

                        case 10:
                            kort = färger[j] + "T";
                            skapakortlek.Add(kort);
                            break;

                        case 11:
                            kort = färger[j] + "J";
                            skapakortlek.Add(kort);
                            break;

                        case 12:
                            kort = färger[j] + "D";
                            skapakortlek.Add(kort);
                            break;

                        case 13:
                            kort = färger[j] + "K";
                            skapakortlek.Add(kort);
                            break;

                        default:
                            kort = färger[j] + i.ToString();
                            skapakortlek.Add(kort);
                            break;
                    }
                }
            }
            return skapaKortlek();
        }
    }
}
