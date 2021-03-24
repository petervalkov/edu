import sys, string

text = sys.argv[1].upper()
key = int(sys.argv[2])

alph = string.uppercase[key:] + string.uppercase[0:key]
encr = text.translate(string.maketrans(string.uppercase, alph))
print(encr)