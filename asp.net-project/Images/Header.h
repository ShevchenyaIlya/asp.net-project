#pragma once
#include <iostream>
using namespace std;

//  F[i]=A[i]-(B[i]*C[i])-D[i]

void evaluation()
{
	__int8 A[8]{ 124, -102, 101, 14, -18, 58, 6, 11 };
	__int8 B[8]{ 100, -7, -6, 0, -4, 3, -12, 10 };
	__int8 C[8]{ 8, 7, 6, 5, 4, 3, 2, 1 };
	__int16 D[8]{ -3, 4, 5, -6, 7, -8, 9, 10 };
	__int16 correctAnswer[8] = { 0 };

	for (int i = 0; i < 8; i++)
	{
		correctAnswer[i] = A[i] - (B[i] * C[i]) - D[i];
	}

	
	__int16 F[8] = { 0 };

	__asm {
		movq mm0, qword ptr [B]
		pcmpgtb mm1, mm0
		punpcklbw mm0, mm1
		movq mm7, mm0
		movq mm0, qword ptr [B]
		pcmpgtb mm1, mm0
		punpckhbw mm0, mm1
		movq mm6, mm0
		movq [F], mm7
		
		movq mm0, qword ptr [C]
		pcmpgtb mm1, mm0
		punpcklbw mm0, mm1
		movq mm5, mm0
		movq mm0, qword ptr [C]
		pcmpgtb mm1, mm0
		punpckhbw mm0, mm1
		movq mm4, mm0

		pmullw mm7, mm5
		pmullw mm6, mm4

		movq mm0, qword ptr [A]
		pcmpgtb mm1, mm0
		punpcklbw mm0, mm1
		movq mm5, mm0
		movq mm0, qword ptr [A]
		pcmpgtb mm1, mm0
		punpckhbw mm0, mm1
		movq mm4, mm0

		psubsw mm5, mm7
		psubsw mm4, mm6

		movq mm7, qword ptr [D]
		movq mm6, qword ptr [D + 2 * 4]
		
		psubsw mm5, mm7
		psubsw mm4, mm6
		
		movq qword ptr [F], mm5
		movq qword ptr [F + 2 * 4], mm4
	}

	for (int i = 0; i < 8; i++)
	{
		cout << F[i] << " ";
	}
	
	cout << endl;
	for(int i = 0; i < 8; i++)
	{
		cout << correctAnswer[i] << " ";
	}
}
