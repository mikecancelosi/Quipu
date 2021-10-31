<template>
  <div class="column">
    <q-drawer v-model="showDetails" side="right" bordered overlay :width="600">
      <taskdetailpreview
        v-if="detailtask.value != null"
        :id="detailtask.value.id"
        @hideDetails="showDetails = false"
      />
    </q-drawer>
    <div id="contentcontainer">
      <div id="tableCommandBar" class="row" style="padding: 15px 30px">
        <q-space />
        <div id="heading-options">
          <q-btn
            label="All Tasks"
            disable
            no-caps
            icon="o_check_circle_outline"
            dense
          />
          <q-btn label="Filter" disable no-caps icon="o_filter_list" dense />
          <q-btn label="Sort" disable no-caps icon="o_import_export" dense />
          <q-btn
            label="Customize"
            disable
            no-caps
            icon="o_dashboard_customize"
            dense
          />
          <q-btn disable no-caps icon="o_more_horiz" dense />
        </div>
      </div>

      <q-table
        :columns="headercolumns"
        :rows="headerrows"
        separator="vertical"
        style="background-color: transparent"
        flat
        hide-pagination
      >
        <template v-slot:header="columnList">
          <div
            class="row"
            style="
              margin: 0px 30px;
              border-bottom: solid 1px gray;
              border-top: solid 1px gray;
            "
          >
            <q-th
              v-for="col in columnList.cols"
              :key="col.name"
              :props="columnList"
            >
              {{ col.label }}
            </q-th>
          </div>
        </template>

        <template v-slot:body="taskRows">
          <q-tr :props="taskRows">
            <q-td id="datacell" key="name" :props="taskRows" colspan="100%">
              <q-expansion-item
                :label="taskRows.row.name"
                v-model="taskRows.row.expanded"
                switch-toggle-side
                expand-icon-toggle
                dense-toggle
                header-style="left:0px"
                style="font-size: 16px; margin: 10px 0px"
              >
                <draggable
                  class="list-group"
                  v-model="taskRows.row.tasks"
                  group="tasks"
                  item-key="id"
                  v-bind="dragOptions"
                  @start="drag = true"
                  @end="drag = false"
                  @change="(arg) => taskfinishedmoving(arg, taskRows.row)"
                  handle=".handle"
                >
                  <template #item="{ element }">
                    <row
                      :id="element.id"
                      :projectid="element.projectID"
                      :categoryid="element.statusCategoryID"
                      @show-detailtask="showTaskDetail(element)"
                    />
                  </template>

                  <template #footer>
                    <div class="addtaskrow" @click="addemptytask(taskRows)">
                      <a style="margin-left: 40px; color: darkgray">
                        Add task...
                      </a>
                    </div>
                  </template>
                </draggable>
              </q-expansion-item>
            </q-td>
          </q-tr>
        </template>
      </q-table>
    </div>
  </div>
</template>

<style scoped>
#heading-options > .q-btn {
  margin-right: 20px;
}

#contentcontainer {
  flex: 1 1 auto;
}

.tablecol {
  width: 10%;
  border-right: 1px solid gray;
  min-height: 40px;
  line-height: 40px;
  padding-left: 10px;
}

.statuscol {
  border-right: 0px;
}

.taskcol {
  width: 60%;
}

.button {
  margin-top: 35px;
}

#datacell {
  padding: 0 !important;
}

.flip-list-move {
  transition: transform 0.5s;
}

.no-move {
  transition: transform 0s;
}

.q-table--dark tbody td:before {
  background-color: transparent;
}

.headercol {
  padding-top: 0px;
  padding-bottom: 0px;
}

.addtaskrow {
  font-size: 14px;
  border-bottom: 0px;
  margin-left: 30px;
  margin-right: 30px;
  cursor: pointer;
  padding: 10px;
  border-top: 1px solid gray;
}

.addtaskrow:hover {
  background-color: RGB(255, 255, 255, 0.1);
}
</style>

<script>
import draggable from "vuedraggable";
import taskdetailpreview from "./ProjectComponents/ProjectTaskList_TaskDetailPreview";
import row from "./ProjectComponents/ProjectTaskList_Row";
import { ref, reactive, computed } from "vue";
import { useStore } from "vuex";

export default {
  name: "ProjectTaskList",
  components: { draggable, taskdetailpreview, row },
  props: {
    project: {},
  },
  setup(props) {
    const store = useStore();
    //Table Setup
    const headercolumns = [
      {
        name: "name",
        label: "Task Name",
        align: "left",
        headerClasses: "headercol tablecol taskcol",
      },
      {
        name: "assignee",
        label: "Assignee",
        align: "left",
        headerClasses: "headercol tablecol assigncol",
      },
      {
        name: "date",
        label: "Date",
        align: "left",
        headerClasses: "headercol tablecol datecol",
      },
      {
        name: "priority",
        label: "Priority",
        align: "left",
        headerClasses: "headercol tablecol prioritycol",
      },
      {
        name: "status",
        label: "Status",
        align: "left",
        headerClasses: "headercol tablecol statuscol",
      },
    ];
    const headerrows = reactive(
      store.getters.getTaskStatusCategoryGroups(props.project)
    );

    //Dragging
    const drag = ref(false);
    const dragOptions = computed(() => {
      return {
        animation: 200,
        group: "description",
        disabled: false,
        ghostClass: "ghost",
      };
    });
    const taskfinishedmoving = (args, group) => {
      if (args.added != null) {
        args.added.element.statusCategory = headerrows.filter(
          (status) => status.id === group.id
        )[0];

        updatetask(args.added.element);
      }
    };

    //Details
    const showDetails = ref(false);
    const detailtask = reactive({});
    const showTaskDetail = (task) => {
      detailtask.value = task;
      showDetails.value = true;
    };

    //Modifications
    const updatetask = (task) => {
      console.log(task);
    };
    const addemptytask = (category) => {
      console.log(category);
      var categoryname = category.row.name;
      var matchresult = headerrows.filter((row) => {
        return row.name === categoryname;
      })[0];

      matchresult.tasks.push({
        name: "",
        description: "",
        completed: false,
        startDate: "0001-01-01T00:00:00",
        endDate: "0001-01-01T00:00:00",
        statusCategoryID: category.row.id,
        projectID: props.project.id,
      });
      console.log(matchresult.tasks);
      //root.$nextTick(() => { root.$refs['nameinput'].focus(); });
    };

    return {
      headercolumns,
      headerrows,
      drag,
      showDetails,
      detailtask,
      updatetask,
      addemptytask,
      taskfinishedmoving,
      dragOptions,
      showTaskDetail,
    };
  },
};
</script>
