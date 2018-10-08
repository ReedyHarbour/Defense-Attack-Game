# Import a library of functions called 'pygame'
import pygame
from math import pi
import enemys 
import random

pygame.init()
 
BLACK = (  0,   0,   0)
WHITE = (255, 255, 255)

GREEN = (118,238,0)
SKYBLUE = (33, 99, 127)
AQUM = (69,139,116)
BROWN = (205,51,51)
COBAIT = (61,89,171)

WIDTH = 1000
HEIGHT = 600
DEF_MARGIN = 20
MARGIN = 20
# Set the height and width of the screen
SIZE = [WIDTH, HEIGHT] # can resize, but should follow 5 * 3


class Game(object):

    def __init__(self):
        self.screen = pygame.display.set_mode(SIZE)
        self.done = False
        self.clock = pygame.time.Clock()
        self.dragging = False
        self.board = enemys.Board()
        self.currPos = None
        self.currColor = None
        self.cards = [SKYBLUE, AQUM, BROWN, COBAIT]

    def updateBoard(self):
        self.board.updateBrick()
        self.board.updateCell()

    def generateCells(self):
        if len(self.board.holes) != 0:
            position = random.choice(list(self.board.holes))
            self.board.addCell(1, position)

    def addBrickToCell(self, pos, color):
        w = (pos[0] - self.gridStartWidth) // self.gridWidth
        h = (pos[1] - self.gridStartHeight) // self.gridHeight
        self.board.addBrick((h,w), color)

    ####################
    # Drawing functions
    ####################

    def drawCards(self):
        size = [WIDTH//5+DEF_MARGIN+MARGIN, DEF_MARGIN+MARGIN, self.gridWidth, self.gridHeight]
        for color in self.cards:
            pygame.draw.rect(self.screen, color, size)
            size[0] += self.gridWidth + MARGIN

        # self.sampleBrikc_draging = False

    def drawBricks(self):
        for brick in self.board.bricks:
            pos = self.getPosition(brick.position, 1)
            pygame.draw.rect(self.screen, brick.color, pos) 

    def drawGrids(self, r, c):
        self.gridWidth = (WIDTH*4//5 - DEF_MARGIN * 2) // r # side length of a grid
        self.gridHeight = (HEIGHT - DEF_MARGIN * 2) * 3 // 4 // c
        self.gridStartWidth = WIDTH//5 + DEF_MARGIN
        self.gridStartHeight = self.gridHeight * 2 + DEF_MARGIN
        for row in range(r):
            for col in range(c):
                size = [self.gridStartWidth + row * self.gridWidth, 
                        self.gridStartHeight + col * self.gridHeight, 
                        self.gridWidth, self.gridHeight]
                pygame.draw.rect(self.screen, WHITE, size, 2)

    def getPosition(self, pos, ctype):
        row,col = pos
        # assert(row < 6 and col < 10)
        lw = self.gridWidth # side length of a grid
        lh = self.gridHeight
        w = self.gridStartWidth
        h = self.gridStartHeight
        if ctype == 0: # circle
            return (w + col * lw + lw//2, h + row * lh + lh//2)
        elif ctype == 1:
            return [self.gridStartWidth + col * self.gridWidth + MARGIN // 2, 
                    self.gridStartHeight + row * self.gridHeight + MARGIN // 2, 
                    self.gridWidth - MARGIN, self.gridHeight - MARGIN]

    def drawCells(self):
        for cell in self.board.cells:
            pos = cell.position
            pygame.draw.circle(self.screen, GREEN, self.getPosition(pos, 0), 25)
    
    def redrawAll(self):
        # Clear the screen and set the screen background
        self.screen.fill(BLACK)
         
        # Draw sidebar
        pygame.draw.rect(self.screen, WHITE, [DEF_MARGIN, DEF_MARGIN, 
                            WIDTH//5-2*DEF_MARGIN,HEIGHT-2*DEF_MARGIN], 2)
             
        # Draw main graph
        pygame.draw.rect(self.screen, WHITE, [WIDTH//5+DEF_MARGIN, DEF_MARGIN, 
                            WIDTH*4//5-2*DEF_MARGIN,HEIGHT-2*DEF_MARGIN], 2)
            
        # Draw grids 
        self.drawGrids(10, 6)

        # Draw cards
        self.drawCards()
            
        # Draw cells
        self.drawCells()

        # Draw bricks
        self.drawBricks()
        # Draw current rectangle, if moving
        if self.dragging and self.currPos:
            pygame.draw.rect(self.screen, self.currColor, [self.currPos[0], self.currPos[1], 
                68, 68]) 

    def run(self):
        counter = 0
        while not self.done:
            # This limits the while loop to a max of 10 times per second.
            # Leave this out and we will use all CPU we can.
            self.clock.tick(10)
            counter = (counter + 1) % 20
            if (counter == 0):
                self.board.addHoles()
                self.generateCells()
            if (counter % 10 == 0): self.updateBoard() 

            for event in pygame.event.get(): # User did something
                if event.type == pygame.QUIT: # If user clicked close
                    self.done = True # Flag that we are done so we exit this loop
                
                # detect mouse dragging the bricks
                elif event.type == pygame.MOUSEBUTTONDOWN:
                    if event.button == 1: 
                        self.currColor = self.screen.get_at(pygame.mouse.get_pos()) 
                        if self.currColor in self.cards:
                            self.dragging = True

                elif event.type == pygame.MOUSEBUTTONUP:
                    if event.button == 1:
                        self.addBrickToCell(event.pos, self.currColor)           
                        self.dragging = False
                        self.currPos = None
                        self.currColor = None

                elif event.type == pygame.MOUSEMOTION:
                    if self.dragging:
                        self.currPos = event.pos
                         
            # All drawing code happens after the for loop and but
            # inside the main while done==False loop.
            self.redrawAll()
            # Go ahead and update the screen with what we've drawn.
            # This MUST happen after all the other drawing commands.
            pygame.display.flip()
         
        # Be IDLE friendly
        pygame.quit()

gameObj = Game()
gameObj.run()
