// MeshUnmanaged.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <cstdio>
#include <Windows.h>
#include <stdlib.h>  

using DecryptFn = int(__stdcall *) (
	const char* InputArray, int InputLength,
	char**OutputArray, int *OutputLength);

static DecryptFn Decrypt;

int Mesh_Initialize(char *Module) {
	HMODULE mod = LoadLibraryA(Module);
	
	Decrypt = reinterpret_cast<DecryptFn>(GetProcAddress(mod, "Decrypt"));
	}


int Mesh_Decrypt(
			const char* InputArray, int InputLength,
			char**OutputArray, int *OutputLength) {
	return Decrypt(InputArray, InputLength, OutputArray, OutputLength);
	}


int Mesh_Free(void *Memory) {
	free(Memory);
	}

