package Starcounter_Apps_KitchenSink_VersionedSettingsTest.vcsRoots

import jetbrains.buildServer.configs.kotlin.v10.*
import jetbrains.buildServer.configs.kotlin.v10.vcs.GitVcsRoot

object Starcounter_Apps_KitchenSink_VersionedSettingsTest_KitchenSinkDevelop : GitVcsRoot({
    uuid = "c8aec862-c391-437c-b95d-41c7c91e3122"
    extId = "Starcounter_Apps_KitchenSink_VersionedSettingsTest_KitchenSinkDevelop"
    name = "KitchenSinkVersionedSettings"
    url = "ssh://git@github.com/starcountersamples/kitchensink"
    branch = "refs/heads/versioned-settings"
    authMethod = uploadedKey {
        uploadedKey = "kitchensink_joozek - revoke after 7.10.2016"
    }
})
