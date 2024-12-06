string filePath = "input";

string[] lines = File.ReadAllLines(filePath);

int rows = lines.Length;
int cols = lines[0].Length;

Player player = new Player(0,0,'N');
char[,] input = new char[rows,cols];

for(int i = 0; i < rows; i++) {
    for(int j = 0; j < cols; j++) {
        input[i,j] = lines[i][j];
        if(input[i,j] == '^') {
            player = new Player(i,j,'N');
        }
        if(input[i,j] == '>') {
            player = new Player(i,j,'E');
        }
        if(input[i,j] == 'v') {
            player = new Player(i,j,'S');
        }
        if(input[i,j] == '<') {
            player = new Player(i,j,'W');
        }
    }
}
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
int ans = 0;


int startX = player.X;
int startY = player.Y;


input[startX,startY] = '.';

while(true) {
    if(player.Direction == 'N'){
        if(player.X -1 < 0) {
            break;
        }
        if(input[player.X - 1, player.Y] == '#'){
            input[player.X, player.Y] = '+';
            player.Direction = 'E';
            if(player.Y + 1 < cols ) {
                player.Y++;
            }
            continue;
        }
        if(input[player.X, player.Y] == '.')
            input[player.X, player.Y] = '|';

        if(input[player.X, player.Y] == '-')
            input[player.X, player.Y] = '+';
        
        if(player.Y + 1 > cols && input[player.X, player.Y + 1] == '-' || input[player.X, player.Y + 1] == '+')
            ans++;


        player.X--;
        continue;

    }
    if(player.Direction == 'E'){
        if(player.Y + 1 > cols ) {
            break;
        }
        if(input[player.X, player.Y + 1] == '#'){
            input[player.X, player.Y] = '+';
            player.Direction = 'S';
            if(player.X + 1 < rows) {
                player.X++;
            }
            continue;
        }
        if(input[player.X, player.Y] == '.')
            input[player.X, player.Y] = '-';

        if(input[player.X, player.Y] == '|')
            input[player.X, player.Y] = '+';

        if(player.X + 1 < rows && input[player.X + 1, player.Y ] == '|' || input[player.X + 1, player.Y] == '+')
            ans++;


        player.Y++;
        continue;

    }
    if(player.Direction == 'S'){
        if(player.X + 1 > rows) {
            break;
        }
        if(input[player.X + 1, player.Y] == '#'){
            input[player.X, player.Y] = '+';
            player.Direction = 'W';
            if(player.Y - 1 >= 0) {
                player.Y--;
            }
            continue;
        }
        if(input[player.X, player.Y] == '.')
            input[player.X, player.Y] = '|';

        if(input[player.X, player.Y] == '-')
            input[player.X, player.Y] = '+';

        if(player.Y - 1 >= 0 && input[player.X, player.Y - 1] == '-' || input[player.X, player.Y - 1] == '+')
            ans++;


        player.X++;
        continue;
    }
    if(player.Direction == 'W'){
        if(player.Y - 1 < 0) {
            break;
        }
        if(input[player.X, player.Y - 1] == '#'){
            input[player.X, player.Y] = '+';
            player.Direction = 'N';
            if(player.X - 1 >= 0) {
                player.X--;
            }
            continue;
        }
        if(input[player.X, player.Y] == '.')
            input[player.X, player.Y] = '-';

        if(input[player.X, player.Y] == '|')
            input[player.X, player.Y] = '+';

        if(player.X - 1 >= 0 && input[player.X - 1, player.Y] == '|' || input[player.X - 1, player.Y] == '+')
            ans++;


        player.Y--;
        continue;

    }
}



Console.WriteLine(ans);
for(int i = 0; i < rows; i++) {
    for(int j = 0; j < cols; j++) {
        Console.Write(input[i,j]);
    }
    Console.WriteLine();
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

