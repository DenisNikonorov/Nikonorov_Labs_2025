import sys

class SquareRoot:
    def __init__(self):
        self.coef_A = 0
        self.coef_B = 0
        self.coef_C = 0
        self.roots_count = 0
        self.roots = []
        self.calculation_sucess = False

    def get_coef_from_str(self, index, prompt):
        try:
            coef_str = sys.argv[index]
            coef = float(coef_str)
            return coef
        except:
            while True:
                coef_str = input(prompt)
                if (coef_str.isdigit() or (coef_str.startswith('-') and coef_str[1:].isdigit())):
                    return float(coef_str)
                else:
                    print("Вы ввели некорректное значение!")

    def get_coef_from_user(self):
        self.coef_A = self.get_coef_from_str(1, "Введите A: ")
        self.coef_B = self.get_coef_from_str(2, "Введите B: ")
        self.coef_C = self.get_coef_from_str(3, "Введите C: ")

    def calculate_roots(self):
        square_roots = []

        if (self.coef_A == 0):
            square_root = -self.coef_C / self.coef_B
            if (square_root < 0):
                self.calculation_sucess = False
            elif (square_root == 0):
                root = square_root**0.5
                self.roots.append(root)
                self.roots_count += 1
                self.calculation_sucess = True
            else:
                root1 = square_root**0.5
                root2 = -square_root**0.5
                self.roots_count += 2
                self.roots.append(root1)
                self.roots.append(root2)
                self.calculation_sucess = True
        elif (self.coef_C == 0):
            self.calculation_sucess = True
            self.roots.append(0)
            self.roots_count += 1
            square_root = -self.coef_B / self.coef_A
            if (square_root == 0):
                self.roots.append(0)
                self.roots_count += 1
            elif(square_root > 0):
                self.roots_count += 2
                self.roots.append(square_root**0.5)
                self.roots.append(-square_root**0.5)
        else:
            D = self.coef_B**2 - 4 * self.coef_A * self.coef_C
            if (D < 0):
                self.calculation_sucess = False
            elif (D == 0):
                self.calculation_sucess = True
                self.roots_count += 1
                self.roots.append(0)
            else:
                self.calculation_sucess = True
                t1 = (-self.coef_B + D**0.5) / (2 * self.coef_A)
                t2 = (-self.coef_B - D**0.5) / (2 * self.coef_A)
                square_roots.append(t1)
                square_roots.append(t2)

                for root in square_roots:
                    if (root == 0):
                        self.roots_count += 1
                        self.roots.append(root)
                    elif (root > 0):
                        self.roots_count += 2
                        self.roots.append(root**0.5)
                        self.roots.append(-(root**0.5))

    def print_roots(self):
        if (self.calculation_sucess == False):
            print("Нет действительных корней!")
        elif (self.roots_count != len(self.roots)):
            print("Ошибка выполнения программы!")
        else:
            for i in range(self.roots_count):
                print(f"x{i + 1} = {self.roots[i]}")


def main():
    r = SquareRoot()
    r.get_coef_from_user()
    r.calculate_roots()
    r.print_roots()

if __name__ == "__main__":
    main()
