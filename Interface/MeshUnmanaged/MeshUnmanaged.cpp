// MeshUnmanaged.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <cstdio>
#include <Windows.h>
#include <stdlib.h>  

#ifdef __cplusplus    // If used by C++ code, 
extern "C" {          // we need to export the C interface
#endif


using DecryptFn = int(__stdcall *) (
	const char* InputArray, int InputLength,
	char**OutputArray, int *OutputLength);

static DecryptFn Decrypt;

__declspec(dllexport) int __cdecl  Mesh_Initialize(const char *Module) {
	HMODULE mod = LoadLibraryA(Module);
	
	Decrypt = reinterpret_cast<DecryptFn>(GetProcAddress(mod, "Decrypt"));

	return 1;
	}


__declspec(dllexport) int __cdecl  Mesh_Decrypt(
			const char* InputArray, int InputLength,
			char**OutputArray, int *OutputLength) {
	return Decrypt(InputArray, InputLength, OutputArray, OutputLength);
	}


__declspec(dllexport) int __cdecl  Mesh_Free(void *Memory) {
	free(Memory);

	return 1;
	}

#ifdef __cplusplus
	}
#endif
