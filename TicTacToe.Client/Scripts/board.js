$(function () {
    isPosibleMove = function (board, row, col) {
        positionInBoard = (row - 1) * 3 + (col - 1);

        if (board[positionInBoard] == '-') {
            // '-' means free position
            return true;
        }

        return false;
    };
});