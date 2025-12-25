import unittest
from main import User, Computer, UserComputer, DataProcessor, create_test_data


class TestDataProcessor(unittest.TestCase):
    def setUp(self):
        computers, users, users_computers = create_test_data()
        self.processor = DataProcessor(computers, users, users_computers)

    def test_task_a1_structure(self):
        result = self.processor.task_a1()

        self.assertGreater(len(result), 0)

        for item in result:
            self.assertEqual(len(item), 3)
            self.assertIsInstance(item[0], str)
            self.assertIsInstance(item[1], int)
            self.assertIsInstance(item[2], str)

    def test_task_a2_calculation(self):
        result = self.processor.task_a2()

        self.assertGreater(len(result), 0)

        for item in result:
            self.assertEqual(len(item), 2)
            self.assertIsInstance(item[0], str)
            self.assertIsInstance(item[1], int)

        for i in range(len(result) - 1):
            self.assertGreaterEqual(result[i][1], result[i + 1][1])

    def test_task_a3_filtering(self):
        result = self.processor.task_a3()

        for item in result:
            self.assertEqual(len(item), 2)
            self.assertIsInstance(item[0], str)
            self.assertIsInstance(item[1], str)
            self.assertIn('компьютер', item[0].lower())

    def test_one_to_many_relationship(self):
        one_to_many = self.processor.get_one_to_many()

        for fio, sal, comp_name in one_to_many:
            computer = next((c for c in self.processor.computers if c.name == comp_name), None)
            self.assertIsNotNone(computer)

            user = next((u for u in self.processor.users if u.fio == fio and u.sal == sal), None)
            self.assertIsNotNone(user)

            self.assertEqual(user.comp_id, computer.id)

    def test_many_to_many_relationship(self):
        many_to_many = self.processor.get_many_to_many()

        for fio, sal, comp_name in many_to_many:
            computer = next((c for c in self.processor.computers if c.name == comp_name), None)
            self.assertIsNotNone(computer)

            user = next((u for u in self.processor.users if u.fio == fio and u.sal == sal), None)
            self.assertIsNotNone(user)

            connection = next((uc for uc in self.processor.users_computers
                              if uc.comp_id == computer.id and uc.user_id == user.id), None)
            self.assertIsNotNone(connection)


class TestDataClasses(unittest.TestCase):
    def test_user_creation(self):
        user = User(1, 'Иванов', 30000, 1)
        self.assertEqual(user.id, 1)
        self.assertEqual(user.fio, 'Иванов')
        self.assertEqual(user.sal, 30000)
        self.assertEqual(user.comp_id, 1)

    def test_computer_creation(self):
        computer = Computer(1, 'компьютер отдела по борьбе с коррупцией')
        self.assertEqual(computer.id, 1)
        self.assertEqual(computer.name, 'компьютер отдела по борьбе с коррупцией')

    def test_user_computer_creation(self):
        user_computer = UserComputer(1, 2)
        self.assertEqual(user_computer.comp_id, 1)
        self.assertEqual(user_computer.user_id, 2)


def run_tests():
    loader = unittest.TestLoader()
    suite = unittest.TestSuite()

    suite.addTests(loader.loadTestsFromTestCase(TestDataProcessor))
    suite.addTests(loader.loadTestsFromTestCase(TestDataClasses))

    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    return result


if __name__ == '__main__':
    run_tests()
