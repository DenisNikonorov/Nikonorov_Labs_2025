import sys

def get_coef(index, prompt):
    try:
        coefStr = sys.argv[index]
        coef = float(coefStr)
        return coef
    except:
        while True:
            coefStr = input(prompt)
            if coefStr.isdigit() or (coefStr.startswith('-') and coefStr[1:].isdigit()):
                coef = float(coefStr)
                return coef
            else:
                print("Вы ввели некорректное значение, введите число: ")

def calculate_roots(a, b, c):
    squareRoots = []
    roots = [True]

    D = b**2 - 4*a*c

    if (a == 0):
        squareRoot = -c/b
        if (squareRoot < 0):
            roots[0] = False
        elif (squareRoot == 0):
            roots.append(0)
        else:
            root1 = squareRoot**0.5
            root2 = -squareRoot**0.5
            roots.append(root1)
            roots.append(root2)
            return roots

    if (D < 0):
        roots[0] = False
    else:
        t1 = (-b + D**0.5) / (2*a)
        t2 = (-b - D**0.5) / (2*a)
        squareRoots.append(t1)
        squareRoots.append(t2)

        for t in squareRoots:
            if (t == 0):
                roots.append(0)
            elif (t > 0):
                root1 = t**0.5
                root2 = -t**0.5
                roots.append(root1)
                roots.append(root2)
    return roots

def main():
    a = get_coef(1, "Введите кэффициент A: ")
    b = get_coef(2, "Введите кэффициент B: ")
    c = get_coef(3, "Введите кэффициент C: ")
    print()

    roots = calculate_roots(a, b, c)
    if (roots[0] == True):
        for i in range(1, len(roots)):
            print(f"x{i} = ", roots[i])
    else:
        print("Нет действительных корней!")

if __name__ == "__main__":
    main()
