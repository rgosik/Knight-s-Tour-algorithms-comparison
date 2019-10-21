public class Chessboard {

    private int board[][];
    private int posX = 0;
    private int posY = 0;

    public Chessboard(int sizeX, int sizeY, int posX, int posY){
        this(sizeX, sizeY);
        this.posX = posX;
        this.posY = posY;
    }

    public Chessboard(int sizeX, int sizeY) {
        board = new int[sizeY][sizeX];
        board[posY][posX] = 1;
    }

    public void move(int x, int y, int iteration){
        posX += x;
        posY += y;
        board[posY][posX] = iteration;
    }

    public int[][] getBoard() {
        return board;
    }

    public void setBoard(int[][] board) {
        this.board = board;
    }

    public int getPosX() {
        return posX;
    }

    public void setPosX(int posX) {
        this.posX = posX;
    }

    public int getPosY() {
        return posY;
    }

    public void setPosY(int posY) {
        this.posY = posY;
    }
}
