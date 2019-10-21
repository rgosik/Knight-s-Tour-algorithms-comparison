public class Chessboard {

    private final int board[][];
    private int kX = 0;
    private int kY = 0;

    public Chessboard(int sizeX, int sizeY, int kX, int kY) {
        this(sizeX, sizeY);
        this.kX = kX;
        this.kY = kY;
    }

    public Chessboard(int sizeX, int sizeY) {
        board = new int[sizeY][sizeX];
        board[kY][kX] = 1;
    }

    public void moveKnight(Moves move, int iteration) {
        kX += move.getX();
        kY += move.getY();
        board[kY][kX] = iteration + 1;
    }

    public int[][] getBoard() {
        return board;
    }

    public int getkX() {
        return kX;
    }

    public int getkY() {
        return kY;
    }
}
