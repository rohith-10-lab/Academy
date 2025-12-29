using System.Text;

var text = new StringBuilder();
for (int i = 0; i < 100; i++) {
   var inp = Console.ReadLine ();
   var idx = inp.IndexOf (" ");
   var command = inp.Substring (0, idx);
   var s = inp.Substring (idx);
   if (command == "ADD") {
      text.Append (s);
      inp = Console.ReadLine ();
      if (inp == "SHOW") {
         Console.WriteLine (text);
      }
   }
   if (inp == "EXIT") break;
}

