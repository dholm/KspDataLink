HOST_OS := $(shell uname -s)
ifeq ($(HOST_OS), Darwin)
	STEAMAPPS_PATH ?= $(HOME)/Library/Application\ Support/Steam/SteamApps
	KSP_PATH ?= $(STEAMAPPS_PATH)/common/Kerbal\ Space\ Program
	KSP_MANAGED_PATH ?= $(KSP_PATH)/KSP.app/Contents/Data/Managed
endif

BUILD_OUTPUT ?= build

CS ?= gmcs

KSPFLAGS ?= -lib:$(KSP_MANAGED_PATH) \
	 -reference:$(KSP_ASSEMBLIES)
CSFLAGS ?= -langversion:4

KSP_ASSEMBLIES := Assembly-CSharp,Assembly-CSharp-firstpass,UnityEngine

TARGETS := Plugin/RSpace.dll
SOURCES := $(wildcard *.cs)

Q := @
ifeq ($(verbose), 1)
	Q :=
endif

ifeq ($(debug), 1)
	CSFLAGS += -debug:full -define:DEBUG
endif

all: $(addprefix build/, $(TARGETS))

%.dll:
	$(Q)mkdir -p $(dir $(@))
	$(Q)$(CS) -t:library -out:$(@) $(KSPFLAGS) $(CSFLAGS) $(^)

$(BUILD_OUTPUT)/Plugin/RSpace.dll: $(SOURCES)

clean:
	$(Q)rm -rf $(BUILD_OUTPUT)

.PHONY: all clean
