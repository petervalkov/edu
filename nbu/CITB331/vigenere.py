import sys, string

keyword = sys.argv[2].upper()
text = sys.argv[1].upper()

encr = list()
for i in range(len(text)):
    key = ord(keyword[i % len(keyword)]) - 65
    alph = string.uppercase[key:] + string.uppercase[0:key]
    encr.append(text[i].translate(string.maketrans(string.uppercase, alph)))

print(''.join(encr))