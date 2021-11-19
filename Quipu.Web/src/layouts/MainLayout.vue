<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <page-header title="Home" />
    </q-header>

    <nav-menu />

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import PageHeader from "components/PageHeader.vue";
import NavMenu from "components/NavMenu.vue";

import { defineComponent, ref } from "vue";

export default defineComponent({
  name: "MainLayout",

  components: {
    PageHeader,
    NavMenu,
  },
});
</script>
