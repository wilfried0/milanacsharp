using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Milana 
{
    class Milanisation
    {
        static void Main(){
            String fileName = "/Users/sprintpay/Downloads/mystere.mp4";
            String saveDirectory = "/Users/sprintpay";

            if (File.Exists(fileName))
            {
                if (Directory.Exists(saveDirectory))
                {
                    String fileNameOnly = "AU_COEUR_DES_MYSTERES";
                    string path = fileName;
                    byte[] TailleFichier = System.IO.File.ReadAllBytes(path); //taille du fichier
                    int niveauDescente = 1;
                    Console.WriteLine("Taille ");
                    Console.WriteLine(TailleFichier.Length);
                    Console.WriteLine(System.Int32.MaxValue);
                    Console.WriteLine(System.Int32.MaxValue/8);
                    
                    if(TailleFichier.Length > 268435455){
                        int nbre = TailleFichier.Length/8;
                        int resteByte = TailleFichier.Length%8;
                        Console.WriteLine("nbre vaut "+nbre);
                        Console.WriteLine("Reste vaut "+resteByte);
                        for(int i=0; i<nbre; i++){
                            byte[] currentTailleFichier = TailleFichier.SubArray(i*268435455, 268435455*(i+1)-1);
                            Console.WriteLine("CurrentTaille x 8 = "+currentTailleFichier.Length * 8+" position "+i);
                            bool[] bits = currentTailleFichier.
                                AsParallel().
                                SelectMany(GetBitss).
                                Take(268435455).
                                ToArray();
                            Console.WriteLine("bits vaut "+bits.Length);
                            int ConditionCompression = 30;
                            bool[][] reste = new bool[ConditionCompression][];

                            while (niveauDescente <= ConditionCompression)
                            {
                                bool[][] bitss;
                                int[][] tabPosition;
                                int[][] tabCountOccurence;
                                decimal[][] tabValeurCalcule;
                                string[][] tabConvertBinaires;
                                int[] tabSommeCalculeValeur;
                                string[] tabIF;
                                string[] tabDoublon;
                                bool[] bitssCurrent = new bool[] { true, false, false, true, true };
                                //make arrange of 76
                                bitss = SetTabList(bits, 76, reste, niveauDescente);

                                tabPosition = SetPositionBitListTab(bitss);

                                tabCountOccurence = TraitementMemeMoment(tabPosition);

                                tabConvertBinaires = ConvertirBinaireStringListTab(tabCountOccurence); // List des tableaux de 37 bits


                                tabDoublon = ListCountNombreOccurenceListTab(tabPosition); // Liste des bits des doublons (12 bits)
                                                                                        //Console.WriteLine("Calcule des valeurs de calcule");
                                tabValeurCalcule = ListTabValeurCalcule(tabPosition);
                                //Console.WriteLine("Les valeurs de IF");
                                tabSommeCalculeValeur = SommeCalculeValeur(tabValeurCalcule, 0);
                                //Console.WriteLine("Les valeurs binaire de IF sur 25 bits");
                                tabIF = IF(tabSommeCalculeValeur); // list of 25bits
                                bits = ChaineRetourn(tabConvertBinaires, tabDoublon, tabIF);
                                var bytes = ConvertBoolArrayToByteArray(bits);
                                string savePath = @saveDirectory + "\\" + fileNameOnly + ".lana";//@"C:\Users\Public\test.lana";
                                StreamWriter sw = new StreamWriter(savePath,true);
                                sw.WriteLine(bytes);
                                //File.WriteAllBytes(savePath, bytes);
                                Console.WriteLine(niveauDescente);
                                niveauDescente++;
                            }
                            niveauDescente = 1;
                        }
                        if(resteByte != 0){
                            niveauDescente = 1;
                            byte[] currentTailleFichier = TailleFichier.SubArray((nbre)*268435455, TailleFichier.Length-1);
                            bool[] bits = currentTailleFichier.SelectMany(GetBitss).ToArray();
                            int ConditionCompression = 30;
                            bool[][] reste = new bool[ConditionCompression][];

                            while (niveauDescente <= ConditionCompression)
                            {
                                bool[][] bitss;
                                int[][] tabPosition;
                                int[][] tabCountOccurence;
                                decimal[][] tabValeurCalcule;
                                string[][] tabConvertBinaires;
                                int[] tabSommeCalculeValeur;
                                string[] tabIF;
                                string[] tabDoublon;
                                bool[] bitssCurrent = new bool[] { true, false, false, true, true };
                                //make arrange of 76
                                bitss = SetTabList(bits, 76, reste, niveauDescente);

                                tabPosition = SetPositionBitListTab(bitss);

                                tabCountOccurence = TraitementMemeMoment(tabPosition);

                                tabConvertBinaires = ConvertirBinaireStringListTab(tabCountOccurence); // List des tableaux de 37 bits


                                tabDoublon = ListCountNombreOccurenceListTab(tabPosition); // Liste des bits des doublons (12 bits)
                                                                                        //Console.WriteLine("Calcule des valeurs de calcule");
                                tabValeurCalcule = ListTabValeurCalcule(tabPosition);
                                //Console.WriteLine("Les valeurs de IF");
                                tabSommeCalculeValeur = SommeCalculeValeur(tabValeurCalcule, 0);
                                //Console.WriteLine("Les valeurs binaire de IF sur 25 bits");
                                tabIF = IF(tabSommeCalculeValeur); // list of 25bits
                                bits = ChaineRetourn(tabConvertBinaires, tabDoublon, tabIF);
                                var bytes = ConvertBoolArrayToByteArray(bits);
                                string savePath = @saveDirectory + "/" + fileNameOnly + ".lana";//@"C:\Users\Public\test.lana";
                                StreamWriter sw = new StreamWriter(savePath,true);
                                sw.WriteLine(bytes);
                                //File.WriteAllBytes(savePath, bytes);
                                Console.WriteLine(niveauDescente);
                                niveauDescente++;
                            }
                        }
                    }else{
                        bool[] bits = TailleFichier.SelectMany(GetBitss).ToArray();
                        int ConditionCompression = 30;
                        bool[][] reste = new bool[ConditionCompression][];

                        while (niveauDescente <= ConditionCompression)
                        {
                            bool[][] bitss;
                            int[][] tabPosition;
                            int[][] tabCountOccurence;
                            decimal[][] tabValeurCalcule;
                            string[][] tabConvertBinaires;
                            int[] tabSommeCalculeValeur;
                            string[] tabIF;
                            string[] tabDoublon;
                            bool[] bitssCurrent = new bool[] { true, false, false, true, true };
                            //make arrange of 76
                            bitss = SetTabList(bits, 76, reste, niveauDescente);

                            tabPosition = SetPositionBitListTab(bitss);

                            tabCountOccurence = TraitementMemeMoment(tabPosition);

                            tabConvertBinaires = ConvertirBinaireStringListTab(tabCountOccurence); // List des tableaux de 37 bits


                            tabDoublon = ListCountNombreOccurenceListTab(tabPosition); // Liste des bits des doublons (12 bits)
                                                                                    //Console.WriteLine("Calcule des valeurs de calcule");
                            tabValeurCalcule = ListTabValeurCalcule(tabPosition);
                            //Console.WriteLine("Les valeurs de IF");
                            tabSommeCalculeValeur = SommeCalculeValeur(tabValeurCalcule, 0);
                            //Console.WriteLine("Les valeurs binaire de IF sur 25 bits");
                            tabIF = IF(tabSommeCalculeValeur); // list of 25bits
                            bits = ChaineRetourn(tabConvertBinaires, tabDoublon, tabIF);
                            var bytes = ConvertBoolArrayToByteArray(bits);
                            string savePath = @saveDirectory + "\\" + fileNameOnly + ".lana";//@"C:\Users\Public\test.lana";
                            File.WriteAllBytes(savePath, bytes);
                            Console.WriteLine(niveauDescente);
                            niveauDescente++;
                        }
                    }
                    List<string> list = new List<string>();
                    for (int i = 0; i < 100; i++)
                        list.Add(i.ToString());
                    {
                        Console.WriteLine("Milanisé avec Succès");
                    }
                } else
                {
                    Console.WriteLine("Selectionner un dossier valide!");
                }
            } else
            {
                Console.WriteLine("Selectionner un fichier valide!");
            }
        }

        public static byte[] ConvertBoolArrayToByteArray(bool[] boolArr)
        {
            byte[] byteArr = new byte[(boolArr.Length + 7) / 8];
            for (int i = 0; i < byteArr.Length; i++)
            {
                byteArr[i] = ReadByte(boolArr, i);
            }
            return byteArr;
        }

        public static byte ReadByte(bool[] source, int index)
        {
            byte result = 0;
            var b = source[index];
            if (b) result |= (byte)(1 << (7 - index));
            return result;
        }

        public static IEnumerable<bool> GetBits(byte b)
        {
            Console.WriteLine("Le byte vaut: "+ b);
            for (int i = 0; i < 8; i++)
            {
                yield return (b & 0x80) != 0;
                b *= 2;
            }
        }

        static IEnumerable<bool> GetBitss(byte b)
        {
            for(int i = 0; i < 8; i++)
            {
                yield return (b % 2 == 0) ? false : true;
                b = (byte)(b >> 1);
            }
        }

        public static bool[][] SetTabList(bool[] tab, int interval, bool[][] tabReste, int niveauTraitement)
        {
            var nombretableau = tab.Length / interval;

            bool[][] list_tab_current = new bool[nombretableau][];
            var resteTableau = tab.Length % interval;
            int j = interval;
            int i = 0;
            int k = 0;
            while (j <= nombretableau * interval)
            {
                List<bool> tab_current = new List<bool>();
                while (i < j)
                {
                    tab_current.Add(tab[i]);
                    i++;
                }

                j += interval;
                list_tab_current[k] = tab_current.ToArray();
                k++;
            }

            if (resteTableau != 0)
            {
                var count = 0;
                bool[] r = new bool[resteTableau];
                for (int w = nombretableau * interval; w < tab.Length; w++)
                {
                    r[count] = tab[w];
                    count++;
                }

                tabReste[niveauTraitement - 1] = r;
            }

            return list_tab_current;
        }

        /////////////////TOP OF LEVEL///////////////////////
        public static int[][] SetPositionBitListTab(bool[][] tab)
        {
            int[][] list_tab_current = new int[tab.Length][];
            for (int i = 0; i < tab.Length; i++)
            {
                _ = new List<int>();
                List<int> tab_current = SetPositionBitTab(tab[i]);
                list_tab_current[i] = tab_current.ToArray();
            }

            return list_tab_current;
        }

        public static List<int> SetPositionBitTab(bool[] tab)
        {
            List<int> tabPosition = new List<int>();
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i])
                {
                    if (i >= 70 && i <= 75)
                    {
                        i++;
                    }
                    tabPosition.Add(i);
                }
            }

            return tabPosition;
        }

        public static bool ExcludeDouble(int n)
        {
            if (n == 1 || n == 2 || n == 3 || n == 4 || n == 5 || n == 6)
            {
                return true;
            }
            else if (n == 11 || n == 22 || n == 33 || n == 44 || n == 55 || n == 66)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int[][] TraitementMemeMoment(int[][] tab)
        {
            var tasks = new List<Task<int[]>>();
            int[][] list_tab_current = new int[tab.Length][];
            int[] result = new int[10];
            foreach (var tabsous in tab)
            {
                tasks.Add(Task.Run(() => {
                    result = CountNombreOccurenceTab(tabsous);
                    return result;
                }));
            }
            var t = Task.WhenAll(tasks);
            try
            {
                t.Wait();

            }
            catch { }

            if (t.Status == TaskStatus.RanToCompletion)
            {
                int indexTab = 0;
                foreach (var item in t.Result)
                {
                    list_tab_current[indexTab] = item;
                    indexTab++;

                }
            }
            else if (t.Status == TaskStatus.Faulted)
                Console.WriteLine("bad");


            return list_tab_current;
        }

        public static int[] CountNombreOccurenceTab(int[] tab)
        {
            int[] resultCurrent = new int[10];
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    bool exist = ExcludeDouble(tab[i]);
                    if (!exist)
                    {
                        foreach (char item in tab[i].ToString())
                        {
                            if (j == Int32.Parse(item.ToString()))
                            {
                                resultCurrent[j] += 1;
                                break;
                            }
                        }
                    }
                }
            }
            return resultCurrent;
        }

        public static string[] ListCountNombreOccurenceListTab(int[][] tab)
        {
            string[] list_tab_doublon = new string[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                string resultDoublon = ConstructionStringDoublon(tab[i]);
                list_tab_doublon[i] = resultDoublon;
            }

            return list_tab_doublon;
        }

        public static string ConstructionStringDoublon(int[] tab)
        {
            bool[] find = new bool[12];
            int k = 0;
            string nombre = "";
            for (int i = 1; i < 7; i++)
            {
                bool s = Array.Exists(tab, x => x == i);
                find[k] = s;
                k++;
            }
            for (int j = 11; j < 67; j += 11)
            {
                bool s = Array.Exists(tab, x => x == j);
                find[k] = s;
                k++;
            }
            foreach (var item in find)
            {
                nombre += item == true ? "1" : "0";
            }

            var taillebits = nombre.Length;
            if (taillebits < 12)
            {
                var reste = 12 - taillebits;
                var i = 0;
                var zero = "";
                while (i < reste)
                {
                    zero += "0";
                    i++;
                }
                nombre = zero + nombre;

            }

            return nombre;
        }

        public static string[][] ConvertirBinaireStringListTab(int[][] tab)
        {
            string[][] list_tab_current = new string[tab.Length][];
            _ = new string[10];
            for (int i = 0; i < tab.Length; i++)
            {
                string[] result = ConvertirBinaireStringTab(tab[i]);
                list_tab_current[i] = result;
            }

            return list_tab_current;
        }

        public static string[] ConvertirBinaireStringTab(int[] tab)
        {
            string[] resultCurrent = new string[10];
            for (int j = 0; j < 10; j++)
            {
                var bits = EcritureBinaire(j, tab[j]);
                resultCurrent[j] = bits.ToString();
            }

            return resultCurrent;
        }

        public static decimal ValeurCalcule(int position)
        {
            decimal partie_entiere = (position + 1);
            decimal partie_decimal = (decimal)(12 + position) / 100;
            decimal nombre = partie_entiere + partie_decimal;

            return nombre;
        }

        public static decimal[][] ListTabValeurCalcule(int[][] tab)
        {
            decimal[][] list_valeur_calcule = new decimal[tab.Length][];
            for (int i = 0; i < tab.Length; i++)
            {
                _ = new decimal[tab[i].Length];
                var valeur_calcule = TabValeurCalcule(tab[i]);
                list_valeur_calcule[i] = valeur_calcule;
            }
            return list_valeur_calcule;
        }

        public static decimal[] TabValeurCalcule(int[] tab)
        {
            decimal[] valeur_calcule = new decimal[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                decimal bits = ValeurCalcule(tab[i]);
                valeur_calcule[i] = bits;
            }

            return valeur_calcule;
        }

        public static int[] SommeCalculeValeur(decimal[][] tab, int startIndex)
        {
            int[] listIF = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                var tab_current = tab[i];
                decimal sommeFinalTab = 0;
                var x = tab_current.Length - 1;
                var interval = 0;
                for (int j = 0; j < tab_current.Length; j++)
                {
                    if ((interval + 1) < x)
                    {
                        sommeFinalTab += (decimal)tab_current[x - interval] / tab_current[x - (interval + 1)];
                    }
                    else
                    {
                        sommeFinalTab += (decimal)tab_current[x - x];
                    }

                    interval += 2;
                }
                var partie_decimal = sommeFinalTab - (int)sommeFinalTab;
                var _nombre_etude = partie_decimal * 100000000;
                var nombre_etude = (int)_nombre_etude;
                var nombreComp = Math.Pow(2, 25) - 1;
                if (nombre_etude <= nombreComp)
                {
                    listIF[i] = nombre_etude;
                }
                else
                {
                    var n = nombre_etude.ToString().Substring(startIndex, 7);
                    listIF[i] = Int32.Parse(n);
                }

            }

            return listIF;
        }

        public static string[] IF(int[] tab)
        {
            string[] listIF = new string[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                var binaire = EcritureBinaireIF(tab[i]);
                listIF[i] = binaire;
            }

            return listIF;
        }

        public static bool[] ChaineRetourn(string[][] tab, string[] tab1, string[] tab2)
        {
            List<bool> list = new List<bool>();
            List<bool> bitsfinaux = list;
            for (int i = 0; i < tab.Length; i++)
            {
                var tabCurrent = tab[i];
                for (int j = 0; j < tabCurrent.Length; j++) //chaque sous tableaux
                {
                    var index = tabCurrent[j];
                    foreach (char indextab in index)
                    {
                        bool k = indextab.ToString() == "1";
                        bitsfinaux.Add(k);
                    }
                }

                //on concatene les 12 bits des doublons et unique
                foreach (char indextab1 in tab1[i])
                {
                    bool k1 = indextab1.ToString() == "1";
                    bitsfinaux.Add(k1);
                }

                //on concatene les 25 bits des IF
                foreach (char indextab2 in tab2[i])
                {
                    bool k2 = indextab2.ToString() == "1";
                    bitsfinaux.Add(k2);
                }
            }
            return bitsfinaux.ToArray();
        }

        public static string EcritureBinaire(int index, int nombreConvertir)
        {
            var bits = Convert.ToString(nombreConvertir, 2);
            var taillebits = bits.Length;
            if (index == 0 || index == 8 || index == 9)
            {
                if (taillebits < 3)
                {
                    bits = taillebits == 1 ? "00" + bits : "0" + bits;
                }

                return bits;
            }
            else
            {
                if (taillebits < 4)
                {
                    bits = taillebits == 1 ? "000" + bits : taillebits == 2 ? "00" + bits : "0" + bits;
                }

                return bits;
            }

        }

        public static string EcritureBinaireIF(int nombreConvertir)
        {
            var bits = Convert.ToString(nombreConvertir, 2);
            var taillebits = bits.Length;
            if (taillebits < 25)
            {
                var reste = 25 - taillebits;
                var i = 0;
                var zero = "";
                while (i < reste)
                {
                    zero += "0";
                    i++;
                }
                bits = zero + bits;

            }

            return bits;
        }
    }
}

public static class Extensions
{
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        T[] result = new T[length];
        Array.Copy(array, offset, result, 0, length);
        return result;
    }
}