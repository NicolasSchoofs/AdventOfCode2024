string filePath = "input";

string[] lines = File.ReadAllLines(filePath);

int rows = lines.Length;
int cols = lines[0].Length;

Player player = new Player(0,0,'N');
char[,] input2 = new char[rows,cols];

for(int i = 0; i < rows; i++) {
    for(int j = 0; j < cols; j++) {
        input2[i,j] = lines[i][j];
        if(input2[i,j] == '^') {
            player = new Player(i,j,'N');
        }
        if(input2[i,j] == '>') {
            player = new Player(i,j,'E');
        }
        if(input2[i,j] == 'v') {
            player = new Player(i,j,'S');
        }
        if(input2[i,j] == '<') {
            player = new Player(i,j,'W');
        }
    }
}
int ans = 0;

Player tempPlayer = new Player(player.X, player.Y, player.Direction);

input2[player.X,player.Y] = '.';

char[,] temp = input2.Clone() as char[,];
for(int i = 0; i < rows; i++) {
    for(int j = 0; j < cols; j++) {
        if(i == player.X && j == player.Y)
            continue;
        if(temp[i,j] == '#')
            continue;
        temp[i,j] = '#';
        if(CheckInfiniteLoop2(temp, tempPlayer)) 
            ans++;

        temp = input2.Clone() as char[,];
        tempPlayer = new Player(player.X, player.Y, player.Direction);
    }
}
Console.WriteLine(ans);
        
//PART 1
/*
int ans = 0;

while(true) {
    if(player.Direction == 'N'){
        if(player.X -1 < 0) {
            ans++;
            break;
        }
        switch(input[player.X - 1,player.Y]){
            case '.':
                input[player.X,player.Y] = 'X';
                player.X--;
                ans++;
                break;
            case 'X':
                input[player.X,player.Y] = 'X';
                player.X--;
                break;
            case '#':
                player.Direction = 'E';
                break;

        }

    }
    if(player.Direction == 'E'){
        if(player.Y + 1 > cols ) {
            ans++;
            break;
        }
        switch(input[player.X,player.Y + 1]){
            case '.':
                input[player.X,player.Y] = 'X';
                player.Y++;
                ans++;
                break;
            case 'X':
                input[player.X,player.Y] = 'X';
                player.Y++;
                break;
            case '#':
                player.Direction = 'S';
                break;

        }

    }
    if(player.Direction == 'S'){
        if(player.X + 1 > rows) {
            ans++;
            break;
        }
        switch(input[player.X + 1,player.Y]){
            case '.':
                input[player.X,player.Y] = 'X';
                player.X++;
                ans++;
                break;
            case 'X':
                input[player.X,player.Y] = 'X';
                player.X++;
                break;
            case '#':
                player.Direction = 'W';
                break;

        }

    }
    if(player.Direction == 'W'){
        if(player.Y - 1 < 0) {
            ans++;
            break;
        }
        switch(input[player.X,player.Y - 1]){
            case '.':
                input[player.X,player.Y] = 'X';
                player.Y--;
                ans++;
                break;
            case 'X':
                input[player.X,player.Y] = 'X';
                player.Y--;
                break;
            case '#':
                player.Direction = 'N';
                break;
        }
    }
}

Console.WriteLine(ans);
*/
/*
*/


//PART 2



bool CheckInfiniteLoop2(char[,] input, Player player) {
    var visited = new HashSet<(int X, int Y, char Direction)>();
    while(true) {
        if (!visited.Add((player.X, player.Y, player.Direction)))
        {
            return true;
        }
        if(player.Direction == 'N'){
            if(player.X -1 < 0) {
                break;
            }
            switch(input[player.X - 1,player.Y]){
                case '.':
                    input[player.X,player.Y] = 'X';
                    player.X--;
                    break;
                case 'X':
                    input[player.X,player.Y] = 'X';
                    player.X--;
                    break;
                case '#':
                    player.Direction = 'E';
                    break;

            }

        }
        if(player.Direction == 'E'){
            if(player.Y + 1 > cols - 1) {
                break;
            }
            switch(input[player.X,player.Y + 1]){
                case '.':
                    input[player.X,player.Y] = 'X';
                    player.Y++;
                    break;
                case 'X':
                    input[player.X,player.Y] = 'X';
                    player.Y++;
                    break;
                case '#':
                    player.Direction = 'S';
                    break;

            }

        }
        if(player.Direction == 'S'){
            if(player.X + 1 > rows - 1) {
                break;
            }
            switch(input[player.X + 1,player.Y]){
                case '.':
                    input[player.X,player.Y] = 'X';
                    player.X++;
                    break;
                case 'X':
                    input[player.X,player.Y] = 'X';
                    player.X++;
                    break;
                case '#':
                    player.Direction = 'W';
                    break;

            }

        }
        if(player.Direction == 'W'){
            if(player.Y - 1 < 0) {
                break;
            }
            switch(input[player.X,player.Y - 1]){
                case '.':
                    input[player.X,player.Y] = 'X';
                    player.Y--;
                    break;
                case 'X':
                    input[player.X,player.Y] = 'X';
                    player.Y--;
                    break;
                case '#':
                    player.Direction = 'N';
                    break;
            }
        }
    }
    return false;

}


public class Player {
    public int X;
    public int Y;
    public char Direction;

    public Player(int x, int y, char direction) {
        X = x;
        Y = y;
        Direction = direction;
    }

}

