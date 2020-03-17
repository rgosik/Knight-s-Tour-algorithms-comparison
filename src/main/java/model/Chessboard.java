package model;

import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.Getter;

@NoArgsConstructor
public class Chessboard {

    @Getter @Setter private int[][] board;
    @Getter @Setter private int knightX = 0;
    @Getter @Setter private int knightY = 0;
    @Getter @Setter private int xSize;
    @Getter @Setter private int ySize;

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

    public void move(Moves move, int iteration) {
        knightX += move.getX();
        knightY += move.getY();
        board[knightY][knightX] = iteration;
    }

    public static Chessboard copy(Chessboard chessboard) {
        Chessboard copy = new Chessboard();
        copy.ySize = chessboard.ySize;
        copy.xSize = chessboard.xSize;
        copy.knightX = chessboard.knightX;
        copy.knightY = chessboard.knightY;
        copy.board = new int[chessboard.ySize][chessboard.xSize];

        for (int i = 0; i < chessboard.board.length; i++) {
            System.arraycopy(chessboard.board[i], 0, copy.board[i], 0, chessboard.xSize);
        }

        return copy;
    }
}
