package com.knightstour.model;

import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
public class Chessboard {

    private int[][] board;
    private int knightX = 0;
    private int knightY = 0;
    private int xSize;
    private int ySize;

    @Builder
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

    public Chessboard copy() {
        Chessboard copy = new Chessboard();
        copy.ySize = ySize;
        copy.xSize = xSize;
        copy.knightX = knightX;
        copy.knightY = knightY;
        copy.board = new int[ySize][xSize];

        for (int i = 0; i < board.length; i++) {
            System.arraycopy(board[i], 0, copy.board[i], 0, xSize);
        }

        return copy;
    }
}
