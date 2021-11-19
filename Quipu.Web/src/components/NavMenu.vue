<template>
  <q-drawer :model-value="leftDrawerOpen.value" show-if-above bordered>
    <q-list class="navigationdrawer">
      <div class="row" style="align-items: center">
        <q-item-label id="header" header>Quipu</q-item-label>
        <q-space />
        <div style="height: fit-content">
          <q-btn
            flat
            dense
            round
            @click="toggleLeftDrawerOpen()"
            aria-label="Menu"
            v-if="leftDrawerOpen"
            icon="mdi-backburger"
          />
        </div>
      </div>

      <div v-for="link in essentialLinks" :key="link.title" v-bind="link">
        <q-item
          dense
          clickable
          :to="{ name: link.dest }"
          :disable="link.disable"
        >
          <q-item-section avatar>
            <q-icon :name="link.icon" />
          </q-item-section>
          <q-item-section>
            <q-item-label>{{ link.title }}</q-item-label>
          </q-item-section>
        </q-item>
      </div>
    </q-list>

    <q-separator />

    <q-expansion-item label="Favorites"> </q-expansion-item>

    <q-separator />

    <q-item style="margin-bottom: 10px">
      <div class="row" style="align-items: center; width: 100%">
        <q-item-label>Teams</q-item-label>

        <q-space />
        <q-btn
          flat
          dense
          round
          icon="o_add"
          @click="this.$router.push('/Teams/Create')"
        />
      </div>
    </q-item>

    <q-list v-for="team in teams" :key="team">
      <q-item
        clickable
        dense
        @click="
          this.$router.push({ name: 'TeamOverview', params: { id: team.id } })
        "
      >
        <q-item-section>
          <div class="row" style="align-items: center">
            <q-avatar
              color="teal-8"
              rounded
              size="10px"
              style="margin-right: 10px"
            />
            <a>{{ team.name }}</a>
            <q-space />
            <q-btn round flat dense icon="o_more_vert" disable></q-btn>
          </div>
        </q-item-section>
      </q-item>
    </q-list>
    <q-space style="min-height: 20px" />
    <q-separator />

    <q-item>
      <div class="row" style="align-items: center; width: 100%">
        <q-item-label>Projects</q-item-label>

        <q-space />

        <div>
          <q-btn flat dense round icon="o_add">
            <q-menu>
              <q-list id="create-proj-pop" dense>
                <a class="popup-heading">Create Project</a>
                <q-item clickable v-close-popup class="popup-item" disable>
                  <q-item-section avatar>
                    <q-icon name="o_dashboardpx" />
                  </q-item-section>
                  <q-item-section>Use a template</q-item-section>
                </q-item>
                <q-separator style="padding: 0px" />
                <q-item
                  clickable
                  v-close-popup
                  class="popup-item"
                  @click="this.$router.push('/Projects/Create')"
                >
                  <q-item-section avatar>
                    <q-icon name="o_note_add" size="20px" />
                  </q-item-section>
                  <q-item-section>Blank Project</q-item-section>
                </q-item>
              </q-list>
            </q-menu>
          </q-btn>
        </div>
      </div>
    </q-item>
  </q-drawer>
</template>

<script>
import { mapActions, useStore } from "vuex";
import { computed } from "vue";

const linksList = [
  {
    title: "Home",
    icon: "o_school",
    dest: "Index",
    disable: false,
  },
  {
    title: "My Tasks",
    icon: "o_code",
    dest: "MyTasks",
    disable: true,
  },
  {
    title: "Inbox",
    icon: "o_chat",
    dest: "Inbox",
    disable: true,
  },
  {
    title: "Projects",
    icon: "o_forum",
    dest: "ProjectsList",
    disable: false,
  },
  {
    title: "Goals",
    icon: "o_rss_feed",
    dest: "Goals",
    disable: true,
  },
];

export default {
  name: "NavMenu",
  setup() {
    const store = useStore();
    const teams = computed(() => store.getters.getTeams);
    const leftDrawerOpen = computed(() => store.getters.leftDrawerOpen);

    return {
      essentialLinks: linksList,
      teams,
      leftDrawerOpen,
    };
  },
  methods: {
    ...mapActions(["toggleLeftDrawerOpen"]),
  },
};
</script>

<style scoped>
.navigationdrawer {
  padding: 10px 20px 20px 20px;
}

#header {
  font-size: 20px;
}
</style>
