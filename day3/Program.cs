using System.Text.RegularExpressions;

string filePath = "input";

string input = File.ReadAllText(filePath);

int ans = 0;

Regex filter = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
Regex onFilter = new Regex(@"do\(\)");
Regex ofFilter = new Regex(@"don\'t\(\)");

MatchCollection matches = filter.Matches(input);
MatchCollection onMatches = onFilter.Matches(input);
MatchCollection ofMatches = ofFilter.Matches(input);

foreach(Match match in matches) {
    string word = match.Value;
    string[] parts = word.Split(",");
    int a = Convert.ToInt32(parts[0].Replace("mul(", ""));
    int b = Convert.ToInt32(parts[1].Replace(")",""));

    int latestOn = onMatches.Where(onMatch => onMatch.Index < match.Index).OrderByDescending(onMatch => onMatch.Index).Select(onMatch => onMatch.Index).DefaultIfEmpty(-1).First();
    int latestOf = ofMatches.Where(ofMatch => ofMatch.Index < match.Index).OrderByDescending(ofMatch => ofMatch.Index).Select(ofMatch => ofMatch.Index).DefaultIfEmpty(-1).First();
    
    if(latestOn < latestOf)
        continue;

    ans += a * b;
}

Console.WriteLine(ans);
