#include "stdafx.h"

using namespace System;
using namespace FirstNumber;
using namespace SecondNumber;
using namespace ThirdNumber;

int main(array<System::String ^> ^args)
{
	FirstNumberInput firstInput;
	String^ firstNumberInput = firstInput.input();
	int first = Convert::ToInt64(firstNumberInput);

	SecondNumberInput secondInput;
	String^ secondNumberInput = secondInput.input();
	int second = Convert::ToInt64(secondNumberInput);

	ThirdNumberInput thirdInput;
	String^ thirdNumberInput = thirdInput.input();
	int third = Convert::ToInt64(thirdNumberInput);

	int sum = first + second + third;
	Console::WriteLine(sum);

    return 0;
}
