import pygame
import random

class Board(object):
    def __init__(self):
        # self.board = [[0] * 10 for i in range(6)]
        self.cells = list()
        self.holes = list()
        self.bricks = list()

    def addCell(self, speed, position):
        cell = Cell(speed, position)
        if cell not in self.cells:
            self.cells.append(cell)

    def addBrick(self, position, color):
        brick = Brick(position, color)
        if brick not in self.bricks:
            self.bricks.append(brick)

    def collisionWith(self, cell):
        for brick in self.bricks:
            if brick.collision(cell):
                brick.life -= 1
                return True
        return False

    def updateCell(self):
        L = []
        for cell in self.cells:
            cell.position = (cell.position[0], max(cell.position[1] - 1, 0))
        for cell in self.cells:
            if not self.collisionWith(cell):
                L.append(cell)
        self.cells = L
        print(len(self.cells))

    def updateBrick(self):
        L = []
        for brick in self.bricks:
            if brick.life > 0:
                L.append(brick)
        self.bricks = L

    def addHoles(self):
        if (len(self.holes) < 6):
            r = random.randint(0, 5)
            if (r, 9) not in self.holes:
                self.holes.append((r, 9))

class Cell(object):
    def __init__(self, speed, position):
        self.speed = speed # : int
        self.position = position # (int, int)

    def moveLeft(self):
        self.position = (self.position[0], self.position[1]-1)
        if self.position[0] == 0:
            print("Game Over")
            return True

    def __hash__(self):
        return hash((self.speed, self.position))

    def __eq__(self, other):
        return self.speed == other.speed and self.position == other.position

    def __repr__(self):
        return str(self.position)

    def increaseSpeed(self):
        self.speed += 1

class Brick(object):
    # add width and length
    # add type later
    def __init__(self, position, color):
        self.position = position
        self.life = 5
        self.color = color

    def collision(self, cell):
        print(cell.position, self.position)
        if (cell.position == self.position):
            self.life -= 1
            return True

    def __hash__(self):
        return hash((self.position, self.color))

    def __eq__(self, other):
        return self.position == other.position and self.color == self.color

    def __repr__(self):
        return "%s, %s, %s" % (str(self.position), str(self.life), str(self.color))
