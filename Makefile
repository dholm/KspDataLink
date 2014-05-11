HOST_OS := $(shell uname -s)
ifeq ($(HOST_OS), Darwin)
	STEAMAPPS_PATH ?= $(HOME)/Library/Application\ Support/Steam/SteamApps
	KSP_PATH ?= $(STEAMAPPS_PATH)/common/Kerbal\ Space\ Program
	KSP_MANAGED_PATH ?= $(KSP_PATH)/KSP.app/Contents/Data/Managed
endif

KSPFLAGS ?= -noconfig -lib:$(KSP_MANAGED_PATH) \
	 -reference:$(KSP_ASSEMBLIES)
CSFLAGS ?=

KSP_ASSEMBLIES := Assembly-CSharp,Assembly-CSharp-firstpass,UnityEngine

SOURCES := $(wildcard *.cs)

Q := @
ifeq ($(verbose), 1)
	Q :=
endif

ifeq ($(debug), 1)
	CSFLAGS += -debug:full -define:DEBUG
endif

CS ?= gmcs

all: RSpace.dll

%.dll:
	$(Q)$(CS) -t:library -out:$(@) $(KSPFLAGS) $(CSFLAGS) $(^)

RSpace.dll: $(SOURCES)

clean:
	$(Q)rm -f RSpace.dll

.PHONY: all clean
