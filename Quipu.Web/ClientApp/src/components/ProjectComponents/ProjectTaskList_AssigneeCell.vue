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
                  v-model="newuser"
                  :hide-dropdown-icon="!hover && !showdropdown"
                  :options="this.useroptions"
                  @update:model-value="updatetask()"
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

<style scoped>
    .cell{
        width:100%;
        height:100%;
    }

</style>

<script>
    export default {
        name: "AssigneeCell",
        emits: ["update-task"],
        props: {
            task: {},
            users: [],
            useroptions: [],
        },
        data() {
            return {
                hover: false,
                showdropdown: false,
                newuser: this.task.assignedToUser,
            }
        },
        methods: {
            assignUserClicked() {
                this.showdropdown = true;
                this.$nextTick(() => { this.$refs.userselect.showPopup() });
            },
            updatetask() {
                this.$emit("update-task", this.newuser);
            },
        },
        mounted() {
            console.log(this.task);
        },

    }
</script>