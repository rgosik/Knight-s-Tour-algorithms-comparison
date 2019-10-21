public enum  Moves{
    ONE(1, -2),
    TWO(2, -1),
    THREE(2, 1),
    FOUR(1, 2),
    FIVE(-1, 2),
    SIX(-2, 1),
    SEVEN(-2, -1),
    EIGHT(-1, -2);

    private final int x;
    private final int y;

    Moves(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public int getX() {
        return x;
    }

    public int getY() {
        return y;
    }
}