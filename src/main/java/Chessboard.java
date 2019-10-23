public class Chessboard{

    private int board[][];
    private int knightX = 0;
    private int knightY = 0;
    private int xSize;
    private int ySize;

    public Chessboard(int sizeX, int sizeY, int knightX, int knightY) {
        this(sizeX, sizeY);
        this.knightX = knightX;
        this.knightY = knightY;
    }

    public Chessboard(int sizeX, int sizeY) {
        board = new int[sizeY][sizeX];
        board[knightY][knightX] = 1;
        ySize = board.length;
        xSize = board[0].length;
    }

    private Chessboard(){}

    public void move(Moves move, int iteration) {
        knightX += move.getX();
        knightY += move.getY();
        board[knightY][knightX] = iteration;
    }

    public static Chessboard copy(Chessboard chessboard){
        Chessboard copy = new Chessboard();
        copy.ySize = chessboard.ySize;
        copy.xSize = chessboard.xSize;
        copy.board = chessboard.board.clone();
        copy.knightX = chessboard.knightX;
        copy.knightY = chessboard.knightY;
        return copy;
    }

    public int[][] getBoard() {
        return board;
    }

    public int getKnightX() {
        return knightX;
    }

    public int getKnightY() {
        return knightY;
    }

    public int getxSize() {
        return xSize;
    }

    public int getySize() {
        return ySize;
    }
}
