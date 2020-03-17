package com.knightstour.model;

import lombok.AllArgsConstructor;
import lombok.Getter;

@AllArgsConstructor
public enum Moves {
    ONE(1, -2),
    TWO(2, -1),
    THREE(2, 1),
    FOUR(1, 2),
    FIVE(-1, 2),
    SIX(-2, 1),
    SEVEN(-2, -1),
    EIGHT(-1, -2);

    @Getter private final int x;
    @Getter private final int y;

}