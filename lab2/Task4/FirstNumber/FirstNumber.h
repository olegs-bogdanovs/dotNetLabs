#pragma once

using namespace System;

namespace FirstNumber {
	public ref class FirstNumberInput
	{
	public:virtual String^ input(void) {
		Console::Write("Input 1st number> ");
		System::String^ number = Console::ReadLine();
		return number;
	}
	};
}
