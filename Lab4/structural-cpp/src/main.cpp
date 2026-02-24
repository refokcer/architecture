#include <iostream>
#include "../include/number_utils.h"

int main()
{
    int upperLimit = 0;
    std::cout << "Enter upper bound: ";
    std::cin >> upperLimit;

    if (!std::cin || upperLimit < 1)
    {
        std::cerr << "Upper bound must be a positive integer." << std::endl;
        return 1;
    }

    const long long result = sumOfSquaresForPrimeOrPerfect(upperLimit);
    std::cout << "Sum of squares = " << result << std::endl;

    return 0;
}
