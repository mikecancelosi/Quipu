<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false">
        <q-btn icon="o_person_outline"
               round
               outline
               dense
               size="10px"
               v-if="hover &&
                     !showdropdown &&
                     task.assignedToUser == null"
               @click="assignUserClicked()"
               :style="{ visibility: task.assignedToUser == null
                                                            ? 'visible'
                                                            : 'collapse'}" />

        <q-select dense
                  ref="userselect"
                  v-model="task.assignedToUser"
                  :hide-dropdown-icon="!hover && !showdropdown"
                  :options="this.useroptions"
                  @update:model-value="updatetask(element)"
                  @popup-hide="showdropdown = false"
                  v-if="showdropdown || task.assignedToUser != null"
                  borderless
                  emit-value>
            <template v-slot:option="scope">
                <q-item v-bind="scope.itemProps">
                    <q-item-section>
                        {{scope.opt.label}}
                    </q-item-section>
                </q-item>
            </template>

            <template v-slot:selected>
                {{task.assignedToUser != null ? task.assignedToUser.display_Name : ''}}
            </template>
        </q-select>


    </div>
</template>

<script>
    export default {
        name: "AssigneeCell",
        props: {
            task: {},
            users: [],
            useroptions: [],
        },
        data() {
            return {
                hover: false,
                showdropdown: false,
            }
        },
        methods: {
            assignUserClicked() {
                this.showdropdown = true;
                this.$nextTick(() => { this.$refs.userselect.showPopup() });
            },
            updatetask(element) {
                
            },
        },
        mounted() {

        },

    }
</script>