public class Chessboard {

    private final int board[][];
    private int kX = 0;
    private int kY = 0;
    private int xSize;
    private int ySize;

    public Chessboard(int sizeX, int sizeY, int kX, int kY) {
        this(sizeX, sizeY);
        this.kX = kX;
        this.kY = kY;
    }

    public Chessboard(int sizeX, int sizeY) {
        board = new int[sizeY][sizeX];
        board[kY][kX] = 1;
        ySize = board.length;
        xSize = board[0].length;
    }

    public void move(Moves move, int iteration) {
        kX += move.getX();
        kY += move.getY();
        board[kY][kX] = iteration;
    }

    public void resetValue(int kX, int kY){
        board[kX][kY] = 0;
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

    public int getxSize() {
        return xSize;
    }

    public int getySize() {
        return ySize;
    }
}
