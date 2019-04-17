# Import a library of functions called 'pygame'
import pygame
from math import pi
import enemys 
import random
import render

pygame.init()
 
BLACK = (  0,   0,   0)
WHITE = (255, 255, 255)

GREEN = (118,238,0)
SKYBLUE = (33, 99, 127)
AQUM = (69,139,116)
BROWN = (205,51,51)
COBAIT = (61,89,171)
GREY = (139,131,120)

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
        self.font = pygame.font.Font('Penelope Anne.ttf', 20)
        self.font.set_bold(True)
        self.font40 = pygame.font.Font('Penelope Anne.ttf', 40)
        self.font40.set_bold(True)
        self.regular = pygame.font.SysFont('Arial', 15)
        self.dragging = False

        self.mode = "START"

        self.board = enemys.Board()
        self.currPos = None
        self.currColor = None
        self.currIndex = None
        self.cards = self.board.brickList

        self.gameOver = False
        self.score = 0
        self.time = 60
        self.coins = 20
        self.ingame = True

    def updateGameStatus(self):
        if self.time == 0:
            self.gameOver = True
            return
        for cell in self.board.cells:
            if cell.position[1] == 0:
                self.gameOver = True
                return
        return

    def updateBoard(self):
        self.board.updateBrick()
        changedScore = self.board.updateCell()
        self.score += changedScore * 10
        # self.coins += changedScore * 2

    def generateCells(self):
        if len(self.board.holes) != 0:
            position = random.choice(list(self.board.holes))
            self.board.addCell(1, position)

    def addBrickToCell(self, pos, color, index):
        w = (pos[0] - self.gridStartWidth) // self.gridWidth
        h = (pos[1] - self.gridStartHeight) // self.gridHeight
        if (w >= 0 and w < 10 and h >= 0 and h < 7):
            # check if the brick is placed in target grid by rule
            if color == self.board.boardColorList[h] and self.coins > 0:
                coins = self.board.addBrick((h,w), color, index)
                self.coins -= coins

    def isValid(self, pos, color):
        (x,y) = pos
        startWidth = WIDTH//5+DEF_MARGIN+MARGIN
        currIndex = (x - startWidth)//(self.gridWidth + MARGIN)
        if color in self.board.boardColorList:
            if currIndex >= 0 and currIndex < 7:
                if y > DEF_MARGIN+MARGIN and y < DEF_MARGIN+MARGIN+self.gridHeight:
                    return currIndex
            return None
        
    ####################
    # Drawing functions
    ####################

    def displayText(self):
        textSurf = self.font.render("Score: "+str(self.score), True, WHITE)
        textRect = textSurf.get_rect()
        startWidth = WIDTH//5+DEF_MARGIN+7*MARGIN+6*self.gridWidth
        size = [startWidth, DEF_MARGIN + MARGIN, 
                            WIDTH//5-2*DEF_MARGIN, 2*DEF_MARGIN]
        textRect.center = (size[0]+size[2]//2, size[1]+size[3]//2)
        self.screen.blit(textSurf, textRect)
        textSurf = self.font.render("Time: "+str(self.time), True, WHITE)
        textRect = textSurf.get_rect()
        size = [startWidth, DEF_MARGIN + MARGIN, 
                            WIDTH//5-2*DEF_MARGIN, 4*DEF_MARGIN]
        textRect.center = (size[0]+size[2]//2, size[1]+size[3]//2)
        self.screen.blit(textSurf, textRect)
        textSurf = self.font.render("Coins: $"+str(self.coins), True, BROWN)
        textRect = textSurf.get_rect()
        size = [startWidth, DEF_MARGIN + MARGIN, 
                            WIDTH//5-2*DEF_MARGIN, 6*DEF_MARGIN]
        textRect.center = (size[0]+size[2]//2, size[1]+size[3]//2)
        self.screen.blit(textSurf, textRect)

        # DISPLAY LEGEND
        textSurf = self.font.render("BRICK NAMES LEGEND: ", True, WHITE)
        textRect = textSurf.get_rect()
        size = [DEF_MARGIN, 6*DEF_MARGIN, 
                            WIDTH//5-2*DEF_MARGIN, 12*DEF_MARGIN]
        textRect.center = (size[0]+size[2]//2, size[1]+size[3]//2)
        self.screen.blit(textSurf, textRect)

        L = ["2FA: ", "2 Factor Autentification",
            "ATV SFTW: ", "Antivirus Software",
            "FRWL: ", "Firewall",
            "PSW MNG: ", "Password Manager",
            "BRS PLGN:", "Browser Plugin",
            "STRN PSW:", "Strong Password"]
        size = [DEF_MARGIN, 14*DEF_MARGIN, 
                            WIDTH//5-2*DEF_MARGIN, 2*DEF_MARGIN]
        color = [BROWN, WHITE]
        for i in range(len(L)):
            textSurf = self.regular.render(L[i], True, color[i%2])
            textRect = pygame.draw.rect(self.screen, BLACK, size)
            # textRect.left = (size[0]+size[2]//2, size[1]+size[3]//2)
            size[1] += DEF_MARGIN
            self.screen.blit(textSurf, textRect)
       
        
    def displayScore(self):
        size = [0, HEIGHT//2-self.gridHeight, 
                WIDTH, 2*self.gridHeight]
        pygame.draw.rect(self.screen, BLACK, size)

        textSurf = self.font.render("Game Over!", True, BROWN)
        textRect = textSurf.get_rect()
        textRect.center = (WIDTH//2, HEIGHT//2 - DEF_MARGIN)
        self.screen.blit(textSurf, textRect)

        textSurf = self.font.render("Your Score is "+str(self.score), True, BROWN)
        textRect = textSurf.get_rect()
        textRect.center = (WIDTH//2, HEIGHT//2)
        self.screen.blit(textSurf, textRect)

        textSurf = self.font.render("Press 'R' to restart! ", True, BROWN)
        textRect = textSurf.get_rect()
        textRect.center = (WIDTH//2, HEIGHT//2 + DEF_MARGIN)
        self.screen.blit(textSurf, textRect)

    def displayDescription(self, index):
        text = self.board.description[index]
        surface = pygame.Surface((WIDTH, HEIGHT), pygame.SRCALPHA)
        size = [WIDTH//5+DEF_MARGIN+MARGIN + index * (self.gridWidth +MARGIN), DEF_MARGIN+MARGIN, 
                self.gridWidth, self.gridHeight]
        newSize = [size[0] + size[2]//2, size[1] + size[3]//2, 3*self.gridWidth, 2*self.gridHeight]
        r = pygame.draw.rect(surface, BLACK, newSize)
        rendered_text = render.render_textrect(text, self.regular, r, WHITE, BLACK)
        surface.blit(rendered_text, r)
        self.screen.blit(surface, (0,0))

    def displayInfo(self, r):
        text = ["Files", "PNC", "Google", "Photos", "Linkedin", "Paypal", "Browser"]
        col = 0
        for row in range(r):
            size = [self.gridStartWidth + col * self.gridWidth, 
                    self.gridStartHeight + row * self.gridHeight, 
                    self.gridWidth, self.gridHeight]
            textSurf = self.font.render(text[row], True, WHITE)
            textRect = textSurf.get_rect()
        
            textRect.center = (size[0] + size[2]//2, size[1] + size[3]//2)
            self.screen.blit(textSurf, textRect)
        

    def drawCards(self):
        size = [WIDTH//5+DEF_MARGIN+MARGIN, DEF_MARGIN+MARGIN, self.gridWidth, self.gridHeight]
        for i in range(len(self.cards)):
            color = self.board.colorList[i]
            name = self.board.brickList[i]
            life = self.board.lifeList[i]
            coin = self.board.scoreList[i]

            pygame.draw.rect(self.screen, color, size)
            textSurf = self.font.render(name, True, WHITE)
            textRect = textSurf.get_rect()

            textRect.center = (size[0]+size[2]//2, size[1]+size[3]//2)
            self.screen.blit(textSurf, textRect)

            textSurf = self.font.render(str(life), True, WHITE)
            textRect = textSurf.get_rect()
            textRect.center = (size[0]+size[2]//2, size[1]+size[3]//2+2*DEF_MARGIN)
            self.screen.blit(textSurf, textRect)

            textSurf = self.font.render("$"+str(coin), True, BROWN)
            textRect = textSurf.get_rect()
            textRect.center = (size[0]+size[2]//2, size[1]+size[3]//2+3*DEF_MARGIN)
            self.screen.blit(textSurf, textRect)
            size[0] += self.gridWidth + MARGIN

            #self.screen.blit(fa,textRect.center)

    def drawHoles(self):
        for hole in self.board.holes:
            pos = hole
            pygame.draw.circle(self.screen, WHITE, self.getPosition(pos, 0), 25, 2)

    def drawBricks(self):
        #surface = pygame.Surface((WIDTH, HEIGHT), pygame.SRCALPHA)
        for brick in self.board.bricks:
            pos = self.getPosition(brick.position, 1)
            # shadow = pygame.draw.circle(surface, (131,139,139,100), self.getPosition(brick.position, 0), brick.radius * 50)
            surface = pygame.Surface((WIDTH, HEIGHT), pygame.SRCALPHA)
            #rect = pygame.draw.rect(self.screen, brick.color, pos)
            if brick.life <= 0: continue
            newColor = tuple(list(brick.color)[:3] + [255 - (brick.defaultLife - brick.life) * (255 // brick.defaultLife)])
            rect = pygame.draw.rect(surface, newColor, pos)
            textSurf = self.font.render(brick.name, True, WHITE)
            textRect = textSurf.get_rect()
            textRect.center = (pos[0]+pos[2]//2, pos[1]+pos[3]//2)
            self.screen.blit(surface, (0,0))
            self.screen.blit(textSurf, textRect)

    def drawGrids(self, c, r):
        self.gridWidth = (WIDTH*4//5 - DEF_MARGIN * 2) // c # side length of a grid
        self.gridHeight = (HEIGHT - DEF_MARGIN * 2) * 3 // 4 // r
        self.gridStartWidth = WIDTH//5 + DEF_MARGIN
        self.gridStartHeight = self.gridHeight * 2 + DEF_MARGIN
        for col in range(c):
            for row in range(r):
                size = [self.gridStartWidth + col * self.gridWidth, 
                        self.gridStartHeight + row * self.gridHeight, 
                        self.gridWidth, self.gridHeight]
                pygame.draw.rect(self.screen, WHITE, size, 2)

    def drawMargin(self, r, c):
        color = self.board.boardColorList
        surface = pygame.Surface((WIDTH, HEIGHT), pygame.SRCALPHA)  # the size of your rect
    
        for row in range(r):
            size = [self.gridStartWidth, self.gridStartHeight + row * self.gridHeight, self.gridWidth * c, self.gridHeight]
            converted = tuple(list(color[row]) + [100])
            rect = pygame.draw.rect(surface, converted, size)

        self.screen.blit(surface, (0,0))

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
        pygame.draw.rect(self.screen, WHITE, [DEF_MARGIN//2, DEF_MARGIN, 
                            WIDTH//5-DEF_MARGIN//2,HEIGHT-DEF_MARGIN*2], 2)
             
        # Draw main graph
        pygame.draw.rect(self.screen, WHITE, [WIDTH//5+DEF_MARGIN, DEF_MARGIN, 
                            WIDTH*4//5-2*DEF_MARGIN,HEIGHT-2*DEF_MARGIN], 2)
            
        # Draw grids 
        self.drawGrids(10, 7)
        self.drawMargin(7, 10)
        self.drawGrids(10, 7)

        # Draw cards
        self.drawCards()
            
        # Draw cells
        self.drawCells()

        # Draw hol、es
        self.drawHoles()

        # Draw bricks
        self.drawBricks()
        # Draw current rectangle, if moving
        if self.dragging and self.currPos:
            pygame.draw.rect(self.screen, self.currColor, [self.currPos[0], self.currPos[1], 
                68, 68]) 
        self.displayText()
        self.displayInfo(7)
        if self.gameOver:
            self.displayScore()

    def run(self):
        counter = 0
        count = 0
        while not self.done:
            if self.mode == "START":
                textSurf = self.font40.render("Welcome...", True, BROWN)
                textRect = textSurf.get_rect()
                textRect.center = (WIDTH//2, HEIGHT//2 - DEF_MARGIN)
                self.screen.blit(textSurf, textRect)

                textSurf = self.font40.render("Press SPACE to start! ", True, BROWN)
                textRect = textSurf.get_rect()
                textRect.center = (WIDTH//2, HEIGHT//2 + DEF_MARGIN)
                self.screen.blit(textSurf, textRect)

                for event in pygame.event.get(): # User did something
                    if event.type == pygame.QUIT: # If user clicked close
                        self.done = True # Flag that we are done so we exit this loop
                    if event.type == pygame.KEYDOWN:
                        if event.key == 32: # space
                            self.mode = "PLAY"

            if self.mode == "PLAY":
                self.clock.tick(8)
                self.redrawAll()
                if not self.gameOver and self.ingame:
                    counter = (counter + 1) % 32
                    count += 1
                    if (counter == 0) and count > 20:
                        self.board.addHoles()
                        self.generateCells()
                    if (counter % 16 == 0): 
                        self.updateBoard() 
                    if (counter % 8 == 0): self.time -= 1
                    self.updateGameStatus()

                for event in pygame.event.get(): # User did something
                    if event.type == pygame.QUIT: # If user clicked close
                        self.done = True # Flag that we are done so we exit this loop
                    if event.type == pygame.KEYDOWN:
                        if event.key == 32: # space
                            self.ingame = not self.ingame
                        if event.key == 114: # R
                            self.done = False
                            self.dragging = False
                            self.board = enemys.Board()
                            self.currPos = None
                            self.currColor = None
                            self.currIndex = None
                            self.cards = self.board.brickList
                            self.gameOver = False
                            self.score = 0
                            self.time = 60
                            self.coins = 20
                            self.ingame = True

                    if not self.gameOver and self.ingame:
                        # detect mouse dragging the bricks
                        if event.type == pygame.MOUSEBUTTONDOWN:
                            if event.button == 1: 
                                color = self.screen.get_at(event.pos)
                                index = self.isValid(event.pos, color)
                                if index != None:
                                    self.currIndex = index
                                    self.currColor = color
                                    self.dragging = True

                        elif event.type == pygame.MOUSEBUTTONUP:
                            if event.button == 1 and self.currIndex != None:
                                self.addBrickToCell(event.pos, self.currColor, self.currIndex)           
                                self.dragging = False
                                self.currIndex = None
                                self.currPos = None
                                self.currColor = None

                        elif event.type == pygame.MOUSEMOTION:
                            if self.dragging:
                                self.currPos = event.pos

                pos = pygame.mouse.get_pos()
                color = self.screen.get_at(pos)
                index = self.isValid(pos, color)
                if index != None:
                    self.displayDescription(index)

                         
            # All drawing code happens after the for loop and but
            # inside the main while done==False loop.
            # self.redrawAll()
            # Go ahead and update the screen with what we've drawn.
            # This MUST happen after all the other drawing commands.
            pygame.display.flip()
        

        # Be IDLE friendly
        if self.done: pygame.quit()

gameObj = Game()
gameObj.run()
