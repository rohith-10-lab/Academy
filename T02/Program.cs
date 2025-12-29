//File.ReadAllLines ("C:\\etc\\dial.txt");
string[] conditions = ["L68", "L30", "R48", "L5", "R60"];
int len = conditions.Length;
List<int> num = [];
for (int i = 0; i < 100; i++) num.Add (i);
int dial = num[50], cnt = 0, length = num.Count;
for (int i = 0; i < len; i++) {
   string s = conditions[i];
   string k = s.Substring (1);
   bool x = int.TryParse (k, out int res);
   // for L
   if (s[0] == 'L' && dial < res) {
      if (dial + res >= length) dial = num[dial + Math.Abs (length - res)];
      else dial = num[length - (res - dial)];
   }
   else if (s[0] == 'L' && dial > res) {
      if (dial + res >= length) dial = num[Math.Abs (dial - res)];
      else dial = num[dial - res];
   }
   // for R
   else if (s[0]=='R' && dial < res) {
     if(dial+res >= length) dial = num[dial + res - length];
     else dial = num[dial + res];
   }
   else if (s[0] == 'R' && dial > res) {
      if (dial + res >= length) dial = num[dial - (num.Count - res)];
      else dial = num[dial + res];
   }
   if(dial == 0) cnt++;
}
Console.WriteLine ($"Dial position: {dial}");
Console.WriteLine ($"Count: {cnt}");
