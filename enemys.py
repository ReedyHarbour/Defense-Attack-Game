import pygame
import random

DARKORANGE = (255,140,0)
DEEPSKY = (0,191,255)
PINK = (255,64,64)

# initiate the brick names and types
FAU = "2FA"
ATV = "ATV SFTW"
FRW = "FRWL"
PWM = "PSW MNG"
BRS = "BRS PLGN"
PSW = "STRN PSW"
brickList = [FAU, ATV, FRW, PWM, BRS, PSW]
scoreList = [1,2,3,3,2,1]
lifeList = [2,3,4,3,2,1]
colorList = [DEEPSKY, DARKORANGE, DARKORANGE, DEEPSKY, PINK, DEEPSKY]
protectRadius = [2,2,2,3,3,1]
coolDownTime = [2,2,2,3,3,1]
boardColorList = [DARKORANGE, DEEPSKY, DEEPSKY, DARKORANGE, DEEPSKY, DEEPSKY, PINK]

with open("description.txt", "r+") as txt:
    description = txt.read().split("\n")

class Board(object):

    def __init__(self):
        # self.board = [[0] * 10 for i in range(6)]
        self.cells = list()
        self.holes = list()
        self.bricks = list()

        self.brickList = brickList
        self.scoreList = scoreList
        self.lifeList = lifeList
        self.colorList = colorList
        self.coolDownTime = coolDownTime
        self.protectRadius = protectRadius

        self.boardColorList = boardColorList
        self.description = description

    def addCell(self, speed, position):
        cell = Cell(speed, position)
        if cell not in self.cells:
            self.cells.append(cell)

    def addBrick(self, position, color, index):
        brick = Brick(position, color, index)
        if brick not in self.bricks:
            self.bricks.append(brick)
            return self.scoreList[index]
        return 0

    def collisionWith(self, cell):
        for brick in self.bricks:
            if brick.collision(cell):
                brick.life -= 1
                return True
        return False

    def updateCell(self):
        L = []
        count = 0
        for cell in self.cells:
            cell.position = (cell.position[0], max(cell.position[1] - 1, 0))
        for cell in self.cells:
            if not self.collisionWith(cell):
                L.append(cell)
            else:
                count += 1
        self.cells = L
        return count

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
    def __init__(self, position, color, index):
        self.position = position
        self.color = color
        self.name = brickList[index]
        self.life = lifeList[index]
        self.defaultLife = lifeList[index]
        self.score = scoreList[index]
        self.radius = protectRadius[index]
        self.coolDown = coolDownTime[index]

    def collision(self, cell):
        return (cell.position == self.position)

    def __hash__(self):
        return hash((self.position, self.name))

    def __eq__(self, other):
        return self.position == other.position and self.name == self.name

    def __repr__(self):
        return "%s, %s, %s" % (str(self.position), str(self.name))

class Accounts(Brick):
    def __init__(self, position, index):
        color = DARKORANGE
        super.__init__(position, color, index)

class Data(Brick):
    def __init__(self, position, index):
        color = DEEPSKY
        super.__init__(position, color, index)

class Browser(Brick):
    def __init__(self, position, index):
        color = PINK
        super.__init__(position, color, index)

        