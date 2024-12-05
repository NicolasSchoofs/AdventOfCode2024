string filePath = "input";

string[] lines = File.ReadAllLines(filePath);
string[] rules = [];
string[] updates = [];
int ans = 0;

foreach(string line in lines) {
    rules = lines.Where(l => l.Contains('|')).ToArray(); 
    updates = lines.Where(l => l.Contains(',')).ToArray(); 
}

foreach(string update in updates) {
    bool failed = false;
    string[] parts = update.Split(',');
    int i = 0;
    foreach(string part in parts) {
        for(int j = 0; j < parts.Count(); j++) {
            foreach(string rule in rules) {
                string[] ruleparts = rule.Split('|');
                if(i == j)
                    continue;
                if(part != ruleparts[0] && part != ruleparts[1])
                    continue;
                if(part == ruleparts[0] && parts[j] == ruleparts[1]){
                    if (i > j){
                        ans += SortParts(parts);
                        failed = true;
                        break;
                    }
                }
                if(part == ruleparts[1] && parts[j] == ruleparts[0]){
                    if(i < j) {
                        ans += SortParts(parts);
                        failed = true;
                        break;
                    }
                }
            }
            if(failed)
                break;

        }
        if(failed)
            break;
        i++;
    }
    //Part 1
    //if(!failed)
    //    ans += Convert.ToInt32(parts[parts.Count()/2]);
}

Console.WriteLine(ans);

//Part 2

int SortParts(string[] parts) {
    string temp = "";
    for(int i = 0; i < parts.Count(); i++) {
        for(int j = 0; j < parts.Count(); j++){
            foreach(string rule in rules) {
                string[] ruleParts = rule.Split('|');
                if(parts[i] == ruleParts[0] && parts[j] == ruleParts[1]) {
                    if (i > j){
                        temp = parts[j];
                        parts[j] = parts[i];
                        parts[i] = temp;
                    }
                }
                if(parts[i] == ruleParts[1] && parts[j] == ruleParts[0]) {
                    if (i < j){
                        temp = parts[j];
                        parts[j] = parts[i];
                        parts[i] = temp;
                    }
                }
            }
        }
    }
    return Convert.ToInt32(parts[parts.Count()/2]);
}





