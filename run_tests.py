import unittest
from test_main import TestDataProcessor, TestDataClasses, run_tests

if __name__ == '__main__':
    result = run_tests()

    print("=" * 60)
    print("Результаты тестирования:")
    print(f"Всего тестов: {result.testsRun}")
    print(f"Успешно: {result.testsRun - len(result.failures) - len(result.errors)}")
    print(f"Провалено: {len(result.failures)}")
    print(f"Ошибок: {len(result.errors)}")
    print("=" * 60)
