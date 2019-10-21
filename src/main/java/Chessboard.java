import java.util.ArrayList;
import java.util.List;

public class Chessboard {

    private final int board[][];
    private List viableMoves;
    private int posX = 0;
    private int posY = 0;

    public Chessboard(int sizeX, int sizeY, int posX, int posY) {
        this(sizeX, sizeY);
        this.posX = posX;
        this.posY = posY;
    }

    public Chessboard(int sizeX, int sizeY) {
        board = new int[sizeY][sizeX];
        board[posY][posX] = 1;
        viableMoves = new ArrayList();
    }

    public void move(int x, int y, int iteration) {
        posX += x;
        posY += y;
        board[posY][posX] = iteration;
    }

    public int[][] getBoard() {
        return board;
    }

    public int getPosX() {
        return posX;
    }

    public int getPosY() {
        return posY;
    }
}
