//File.ReadAllLines ("C:\\etc\\dial.txt");
string[] conditions = ["L68", "L30", "R48", "L5", "R60"];
int len = conditions.Length;
List<int> num = [];
for (int i = 0; i < 100; i++) num.Add (i);
int dial = num[50],cnt = 0;
for (int i = 0; i < len; i++) {
   string s = conditions[i];
   string k = s.Substring (1);
   bool x = int.TryParse (k, out int res);
   // for L
   if (s[0] == 'L' && dial < res) {
      dial = num[dial + Math.Abs(num.Count - res)];
   }
   else if (s[0] == 'L' && dial > res) {
      dial = num[Math.Abs(dial - res)];
   }
   // for R
   else if (s[0]=='R' && dial < res) {
      dial = num[dial + res];
   }
   else if (s[0] == 'R' && dial > res) {
      dial = num[Math.Abs(dial - Math.Abs(num.Count - res))];
   }
   if(dial == 0) cnt++;
}
Console.WriteLine ($"Dial position: {dial}");
Console.WriteLine ($"Count: {cnt}");
