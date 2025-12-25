from operator import itemgetter

class User:
    def __init__(self, id, fio, sal, comp_id):
        self.id = id
        self.fio = fio
        self.sal = sal
        self.comp_id = comp_id

class Computer:
    def __init__(self, id, name):
        self.id = id
        self.name = name

class UserComputer:
    def __init__(self, comp_id, user_id):
        self.comp_id = comp_id
        self.user_id = user_id


class DataProcessor:
    def __init__(self, computers, users, users_computers):
        self.computers = computers
        self.users = users
        self.users_computers = users_computers

    def get_one_to_many(self):
        return [(u.fio, u.sal, c.name)
                for c in self.computers
                for u in self.users
                if u.comp_id == c.id]

    def get_many_to_many(self):
        many_to_many_temp = [(c.name, uc.comp_id, uc.user_id)
                            for c in self.computers
                            for uc in self.users_computers
                            if c.id == uc.comp_id]

        return [(u.fio, u.sal, comp_name)
                for comp_name, comp_id, user_id in many_to_many_temp
                for u in self.users if u.id == user_id]

    def task_a1(self):
        one_to_many = self.get_one_to_many()
        return sorted(one_to_many, key=itemgetter(2))

    def task_a2(self):
        one_to_many = self.get_one_to_many()
        result = []

        for c in self.computers:
            c_users = list(filter(lambda i: i[2] == c.name, one_to_many))
            if len(c_users) > 0:
                c_sals = [sal for _, sal, _ in c_users]
                c_sals_sum = sum(c_sals)
                result.append((c.name, c_sals_sum))

        return sorted(result, key=itemgetter(1), reverse=True)

    def task_a3(self):
        many_to_many = self.get_many_to_many()
        result = []

        for c in self.computers:
            if 'компьютер' in c.name:
                c_users = list(filter(lambda i: i[2] == c.name, many_to_many))
                c_users_names = [x for x, _, _ in c_users]
                for user_name in c_users_names:
                    result.append((c.name, user_name))

        return result


def create_test_data():
    computers = [
        Computer(1, 'компьютер отдела по борьбе с коррупцией'),
        Computer(2, 'архивный компьютер'),
        Computer(3, 'бухгалтерский компьютер'),
        Computer(11, 'игровой компьютер отдела кадров'),
        Computer(22, 'компьютер учета взяток'),
        Computer(33, 'компьютер главного бездельника'),
    ]

    users = [
        User(1, 'Сидоров', 25000, 1),
        User(2, 'Петров', 35000, 2),
        User(3, 'Яковлев', 45000, 3),
        User(4, 'Иванов', 35000, 3),
        User(5, 'Грелкин', 25000, 3),
    ]

    users_computers = [
        UserComputer(1, 1),
        UserComputer(2, 2),
        UserComputer(3, 3),
        UserComputer(3, 4),
        UserComputer(3, 5),
        UserComputer(11, 1),
        UserComputer(22, 2),
        UserComputer(33, 3),
        UserComputer(33, 4),
        UserComputer(33, 5),
    ]

    return computers, users, users_computers


def print_table(headers, data):
    if not data:
        return

    col_widths = []
    for i in range(len(headers)):
        col_width = max(len(str(headers[i])),
                       max(len(str(row[i])) for row in data))
        col_widths.append(col_width)

    header_row = "  ".join(f"{headers[i]:<{col_widths[i]}}" for i in range(len(headers)))
    print(header_row)

    separator = "  ".join("-" * col_widths[i] for i in range(len(headers)))
    print(separator)

    for row in data:
        data_row = "  ".join(f"{str(row[i]):<{col_widths[i]}}" for i in range(len(row)))
        print(data_row)
    print()


def main():
    computers, users, users_computers = create_test_data()
    processor = DataProcessor(computers, users, users_computers)

    print('Задание A1')
    print('Список всех связанных пользователей и компьютеров (сортировка по компьютерам)')
    result_a1 = processor.task_a1()
    print_table(['Фамилия', 'Зарплата', 'Компьютер'], result_a1)

    print('Задание A2')
    print('Список компьютеров с суммарной зарплатой пользователей')
    result_a2 = processor.task_a2()
    print_table(['Компьютер', 'Суммарная зарплата'], result_a2)

    print('Задание A3')
    print('Компьютеры с названием содержащим "компьютер" и их пользователи')
    result_a3 = processor.task_a3()
    print_table(['Компьютер', 'Пользователь'], result_a3)


if __name__ == '__main__':
    main()
