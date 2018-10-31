def main(n):
	if n == 0: return -1
	if n == 1: return 0
	return main(n-1)**2 - (n+1)**2 * main(n-2) - 1

for i in range(10):
	print(main(i))