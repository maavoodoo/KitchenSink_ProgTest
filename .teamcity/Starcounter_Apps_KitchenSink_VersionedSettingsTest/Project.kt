package Starcounter_Apps_KitchenSink_VersionedSettingsTest

import Starcounter_Apps_KitchenSink_VersionedSettingsTest.vcsRoots.*
import Starcounter_Apps_KitchenSink_VersionedSettingsTest.vcsRoots.Starcounter_Apps_KitchenSink_VersionedSettingsTest_KitchenSinkDevelop
import jetbrains.buildServer.configs.kotlin.v10.*
import jetbrains.buildServer.configs.kotlin.v10.Project
import jetbrains.buildServer.configs.kotlin.v10.projectFeatures.VersionedSettings
import jetbrains.buildServer.configs.kotlin.v10.projectFeatures.VersionedSettings.*
import jetbrains.buildServer.configs.kotlin.v10.projectFeatures.versionedSettings

object Project : Project({
    uuid = "52c78321-4a52-430c-ac1a-93af364bc790"
    extId = "Starcounter_Apps_KitchenSink_VersionedSettingsTest"
    parentId = "Starcounter_Apps_KitchenSink"
    name = "Versioned Settings Test"
    description = "experiment owned by joozek"

    vcsRoot(Starcounter_Apps_KitchenSink_VersionedSettingsTest_KitchenSinkDevelop)

    features {
        versionedSettings {
            id = "PROJECT_EXT_3"
            mode = VersionedSettings.Mode.ENABLED
            buildSettingsMode = VersionedSettings.BuildSettingsMode.PREFER_SETTINGS_FROM_VCS
            rootExtId = Starcounter_Apps_KitchenSink_VersionedSettingsTest_KitchenSinkDevelop.extId
            showChanges = true
            settingsFormat = VersionedSettings.Format.KOTLIN
        }
    }
})
