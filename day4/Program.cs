
string filePath = "input";

string[] lines = File.ReadAllLines(filePath);

int rows = lines.Length;
int cols = lines[0].Length;

char[,] input = new char[rows,cols];

for(int i = 0; i < rows; i++) {
    for(int j = 0; j < cols; j++) {
        input[i,j] = lines[i][j];
    }
}



//PART1
/*

int ans = 0;

for(int i = 0; i < rows; i++) {
    for(int j = 0; j < cols; j++) {
        if(input[i,j] == 'X') {
            foreach(Coord foundM in FindAround(i,j,'M')) {
                Coord foundA = FindDirection(foundM.X, foundM.Y, 'A', foundM.Direction);
                if(foundA != null) {
                    Coord foundS = FindDirection(foundA.X, foundA.Y, 'S', foundA.Direction);
                    if(foundS != null)
                        ans++;
                }
            }
        }
    }
}

Console.WriteLine(ans);
*/

//PART2
int ans = 0;

List<Coord> FoundAs = new List<Coord>();

for(int i = 0; i < rows; i++) {
    for(int j = 0; j < cols; j++) {
        if(input[i,j] == 'M') {
            foreach(Coord foundA in FindAroundPart2(i,j,'A')) {
                Coord foundS = FindDirection(foundA.X, foundA.Y, 'S', foundA.Direction);
                if(foundS != null) {
                    FoundAs.Add(foundA);
                }
            }
        }
    }
}


for (int i = 0; i < FoundAs.Count; i++)
{
    for (int j = i + 1; j < FoundAs.Count; j++) 
    {
        Coord a = FoundAs[i];
        Coord b = FoundAs[j];

        if (a.X == b.X && a.Y == b.Y)
        {
            ans++;
        }
    }
}

Console.WriteLine(ans);

//DEEL1
List<Coord> FindAround(int i, int j, char letter) {
    List<Coord> output = new List<Coord>();
    for(int k = -1; k < 2; k++) {
        for(int l = -1; l < 2; l++) {
            if(i + k < 0 || i + k >= rows || j + l < 0 || j + l >= cols) {
                continue;
            }
            if(input[i + k, j + l] == letter) {
                if(k == -1 && l == -1) {
                    output.Add(new Coord(i + k, j + l, "upleft"));
                } else if(k == -1 && l == 0) {
                    output.Add(new Coord(i + k, j + l, "up"));
                } else if(k == -1 && l == 1) {
                    output.Add(new Coord(i + k, j + l, "upright"));
                } else if(k == 0 && l == -1) {
                    output.Add(new Coord(i + k, j + l, "left"));
                } else if(k == 0 && l == 1) {
                    output.Add(new Coord(i + k, j + l, "right"));
                } else if(k == 1 && l == -1) {
                    output.Add(new Coord(i + k, j + l, "downleft"));
                } else if(k == 1 && l == 0) {
                    output.Add(new Coord(i + k, j + l, "down"));
                } else if(k == 1 && l == 1) {
                    output.Add(new Coord(i + k, j + l, "downright"));
                }
            }
        }
    }
    return output;
}

Coord FindDirection(int i, int j, char letter, string direction) {
    switch(direction) {
        case "up":
            if(i - 1 >= 0 && input[i - 1, j] == letter) {
                return new Coord(i - 1, j, direction);
            }
            break;
        case "down":
            if(i + 1 < rows && input[i + 1, j] == letter) {
                return new Coord(i + 1, j, direction);
            }
            break;
        case "left":
            if(j - 1 >= 0 && input[i, j - 1] == letter) {
                return new Coord(i, j - 1, direction);
            }
            break;
        case "right":
            if(j + 1 < cols && input[i, j + 1] == letter) {
                return new Coord(i, j + 1, direction);
            }
            break;
        case "upleft":
            if(i - 1 >= 0 && j - 1 >= 0 && input[i - 1, j - 1] == letter) {
                return new Coord(i - 1, j - 1, direction);
            }
            break;
        case "upright":
            if(i - 1 >= 0 && j + 1 < cols && input[i - 1, j + 1] == letter) {
                return new Coord(i - 1, j + 1, direction);
            }
            break;
        case "downleft":
            if(i + 1 < rows && j - 1 >= 0 && input[i + 1, j - 1] == letter) {
                return new Coord(i + 1, j - 1, direction);
            }
            break;
        case "downright":
            if(i + 1 < rows && j + 1 < cols && input[i + 1, j + 1] == letter) {
                return new Coord(i + 1, j + 1, direction);
            }
            break;

        default:
            return null;
    }
    return null;
}



//DEEL2
List<Coord> FindAroundPart2(int i, int j, char letter) {
    List<Coord> output = new List<Coord>();
    if(i - 1 >= 0 && j - 1 >=0 && input[i - 1, j - 1] == letter) {
        output.Add(new Coord(i - 1, j - 1, "upleft"));
    }
    if(i - 1 >= 0 && j + 1 < cols &&  input[i - 1, j + 1] == letter) {
        output.Add(new Coord(i - 1, j + 1, "upright"));
    }
    if(i + 1 < rows && j - 1 >= 0 && input[i + 1, j - 1] == letter) {
        output.Add(new Coord(i + 1, j - 1, "downleft"));
    }
    if(i + 1 < rows && j + 1 < cols && input[i + 1, j + 1] == letter) {
        output.Add(new Coord(i + 1, j + 1, "downright"));
    }
    return output;
}






class Coord {
    public int X {get;set;}
    public int Y {get;set;}
    public string Direction {get;set;}

    public Coord(int x, int y, string direction) {
        this.X = x;
        this.Y = y;
        this.Direction = direction;
    }
}
